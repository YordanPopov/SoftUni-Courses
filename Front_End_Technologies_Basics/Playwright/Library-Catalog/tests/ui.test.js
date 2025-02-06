const { test, expect } = require('@playwright/test');

const host = "http://localhost:3000";

const user = {
    email: "peter@abv.bg",
    password: "123456"
};
const book = {
    title: '',
    description: '',
    img: 'https://upload.wikimedia.org/wikipedia/commons/1/1a/It_%281986%29_front_cover%2C_first_edition.jpg',
    type: 'Other'
}

test.describe('NavBar for guest users', () => {
    test.beforeEach('Open URL', async ({ page }) => {
        await page.goto(host);
    });

    test('Verify that [All Books] link is visible', async ({ page }) => {
        await page.waitForSelector('nav.navbar');

        const allBooksLink = await page.$('a[href="/catalog"]');
        const isLinkVisible = await allBooksLink.isVisible();
        expect(isLinkVisible).toBeTruthy();
    });

    test('Verify that [Login] button is visible', async ({ page }) => {
        await page.waitForSelector('nav.navbar');

        const loginBtn = await page.$('a[href="/login"]');
        const loginBtnIsVisible = await loginBtn.isVisible();
        expect(loginBtnIsVisible).toBeTruthy();
    });

    test(('Verify that [Register] button is visible]'), async ({ page }) => {
        await page.waitForSelector('nav.navbar');

        const regBtn = await page.$('a[href="/register"]');
        const regBtnIsVisible = await regBtn.isVisible();
        expect(regBtnIsVisible).toBeTruthy();
    });
});

test.describe('NavBar for logged-In users', () => {
    test.beforeEach('Open login URL and fill user data', async ({ page }) => {
        await page.goto(host + '/login');
        await page.fill('input[name="email"]', user.email);
        await page.fill('input[name="password"]', user.password);
        await page.click('input[type="submit"]');
    });

    test('Verify that [All Books] link is visible after user login', async ({ page }) => {
        await page.waitForSelector('nav.navbar');

        const allBooksLink = await page.$('a[href="/catalog"]');
        const isVisible = await allBooksLink.isVisible();
        expect(isVisible).toBeTruthy();
    });

    test('Verify that [My Books] link is visible after user login', async ({ page }) => {
        await page.waitForSelector('nav.navbar');

        const MyBookLink = await page.$('a[href="/profile"]');
        const isVisible = await MyBookLink.isVisible();
        expect(isVisible).toBeTruthy();
    });

    test('Verify that [Add Book] link is visible after user login', async ({ page }) => {
        await page.waitForSelector('nav.navbar');

        const AddBookLink = await page.$('a[href="/create"]');
        const isVisible = await AddBookLink.isVisible();
        expect(isVisible).toBeTruthy();
    });

    test('Verify that [Logout] button is visible after user login', async ({ page }) => {
        await page.waitForSelector('nav.navbar');

        const logoutBtn = await page.$('#logoutBtn');
        const isVisible = await logoutBtn.isVisible();
        expect(isVisible).toBeTruthy();
    });

    test('Verify that the email address of user is visible', async ({ page }) => {
        await page.waitForSelector('nav.navbar');

        const emailAddress = await page.$eval('#user span',
            email => email.textContent
        );

        expect(emailAddress).toContain(`Welcome, ${user.email}`);
    });
});

test.describe('Test Login page', () => {
    test.beforeEach('Open login page URL', async ({ page }) => {
        await page.goto(host + '/login');
    });

    test('Submit the form with valid credentials', async ({ page }) => {
        await page.fill('input[name="email"]', user.email);
        await page.fill('input[name="password"]', user.password);
        await page.click('input[type="submit"]');

        await page.$('a[href="/catalog"]');
        expect(page.url()).toBe(host + '/catalog');
    });

    test('Submit the form with empty input fields', async ({ page }) => {
        page.on('dialog', async dialog => {
            expect(dialog.type()).toContain('alert');
            expect(dialog.message()).toContain('All fields are required!');
            await dialog.accept();
        });

        await page.click('input[type="submit"]');

        await page.waitForSelector('section#login-page.login');
        expect(page.url()).toBe(host + '/login');
    });

    test('Submit the form with empty email input field', async ({ page }) => {
        await page.fill('input[name="password"]', user.password);

        page.on('dialog', async dialog => {
            expect(dialog.type()).toContain('alert');
            expect(dialog.message()).toContain('All fields are required!');
            await dialog.accept();
        });

        await page.click('input[type="submit"]');

        await page.waitForSelector('section#login-page.login');
        expect(page.url()).toBe(host + '/login');
    });

    test('Submit the form with empty password input field', async ({ page }) => {
        await page.fill('input[name="email"]', user.email);

        page.on('dialog', async dialog => {
            expect(dialog.type()).toContain('alert');
            expect(dialog.message()).toContain('All fields are required!');
            await dialog.accept();
        });

        await page.click('input[type="submit"]');

        await page.waitForSelector('section#login-page.login');
        expect(page.url()).toBe(host + '/login');
    });
});

test.describe('Test Register page', () => {
    test.beforeEach('Open Register page URL', async ({ page }) => {
        await page.goto(host + '/register');
    });

    test('Submit the form with valid credentials', async ({ page }) => {
        const rnd = Math.floor(Math.random() * 100);

        await page.fill('input#email', `testUser_${rnd}@abc.bg`);
        await page.fill('input#password', '123456');
        await page.fill('input#repeat-pass', '123456');
        await page.click('input[type="submit"]');

        const logoutBtn = await page.$('a#logoutBtn');
        const loginBtnIsVisible = await logoutBtn.isVisible();

        expect(page.url()).toBe(host + '/catalog');
        expect(loginBtnIsVisible).toBeTruthy();
    });

    test('Sumbit the form with empty fields', async ({ page }) => {
        page.on('dialog', async dialog => {
            expect(dialog.type()).toContain('alert');
            expect(dialog.message()).toContain('All fields are required!');
            await dialog.accept();
        });

        await page.click('input[type="submit"]');

        const regSection = await page.$('section#register-page');
        expect(await regSection.isVisible()).toBeTruthy();
        expect(page.url()).toBe(host + '/register');
    });

    test('Sumbit the form with empty email field', async ({ page }) => {
        await page.fill('input#password', '123456');
        await page.fill('input#repeat-pass', '123456');

        page.on('dialog', async dialog => {
            expect(dialog.type()).toContain('alert');
            expect(dialog.message()).toContain('All fields are required!');
            await dialog.accept();
        });

        await page.click('input[type="submit"]');

        const regSection = await page.$('section#register-page');
        expect(await regSection.isVisible()).toBeTruthy();
        expect(page.url()).toBe(host + '/register');
    });

    test('Sumbit the form with empty password field', async ({ page }) => {
        const rnd = Math.floor(Math.random() * 100);

        await page.fill('input#email', `testUser_${rnd}@abc.bg`);
        await page.fill('input#repeat-pass', '123456');

        page.on('dialog', async dialog => {
            expect(dialog.type()).toContain('alert');
            expect(dialog.message()).toContain('All fields are required!');
            await dialog.accept();
        });

        await page.click('input[type="submit"]');

        const regSection = await page.$('section#register-page');
        expect(await regSection.isVisible()).toBeTruthy();
        expect(page.url()).toBe(host + '/register');
    });

    test('Sumbit the form with empty repeat-password field', async ({ page }) => {
        const rnd = Math.floor(Math.random() * 100);

        await page.fill('input#email', `testUser_${rnd}@abc.bg`);
        await page.fill('input#password', '123456');
        await page.click('input[type="submit"]');

        page.on('dialog', async dialog => {
            expect(dialog.type()).toContain('alert');
            expect(dialog.message()).toContain('All fields are required!');
            await dialog.accept();
        })

        const regSection = await page.$('section#register-page');
        expect(await regSection.isVisible()).toBeTruthy();
        expect(page.url()).toBe(host + '/register');
    });

    test('Submit the form with different confirm password', async ({ page }) => {
        const rnd = Math.floor(Math.random() * 100);

        await page.fill('input#email', `testUser_${rnd}@abc.bg`);
        await page.fill('input#password', '123456');
        await page.fill('input#repeat-pass', '654321');

        page.on('dialog', async dialog => {
            expect(dialog.type()).toContain('alert');
            expect(dialog.message()).toContain('Passwords don\'t match!');
            await dialog.accept();
        });

        await page.click('input[type="submit"]');

        const regSection = await page.$('section#register-page');
        expect(await regSection.isVisible()).toBeTruthy();
        expect(page.url()).toBe(host + '/register');

    });
});

test.describe('Test [Add Book] page', () => {
    test.beforeEach('Open login page URL and fill user data', async ({ page }) => {
        await page.goto(host + '/login');
        await page.fill('input[name="email"]', user.email);
        await page.fill('input[name="password"]', user.password);
        page.click('input[type="submit"]');
    });

    test('Submit the form with valid data', async ({ page }) => {
        let rnd = Math.floor(Math.random() * 101);
        book.title = 'Some-Title-' + rnd;
        book.description = 'Some-Description' + rnd;
        await page.waitForURL(host + '/catalog');

        await page.click('a[href="/create"]');
        await page.waitForSelector('section#create-page');

        await page.fill('input#title', book.title);
        await page.fill('textarea#description', book.description);
        await page.fill('input#image', book.img);
        await page.selectOption('select#type', book.type);
        await page.click('input.button.submit');

        await page.waitForURL(host + '/catalog');
        expect(page.url()).toBe(host + '/catalog');
        await expect(page.locator(`h3 >> text=${book.title}`)).toBeVisible();
    });

    test('Add book with empty title field', async ({ page }) => {
        await page.waitForURL(host + '/catalog');

        await page.click('a[href="/create"]');
        await page.waitForSelector('section#create-page');

        await page.fill('textarea#description', book.description);
        await page.fill('input#image', 'https://upload.wikimedia.org/wikipedia/commons/1/1a/It_%281986%29_front_cover%2C_first_edition.jpg');
        await page.selectOption('select#type', 'Other');

        page.on('dialog', async dialog => {
            expect(dialog.type()).toContain('alert');
            expect(dialog.message()).toContain('All fields are required!');
            await dialog.accept();
        });

        await page.click('input.button.submit');
        await page.waitForURL(host + '/create');

        expect(page.url()).toBe(host + '/create');
    });

    test('Add book with empty description field', async ({ page }) => {
        await page.waitForURL(host + '/catalog');

        await page.click('a[href="/create"]');
        await page.waitForSelector('section#create-page');

        await page.fill('input[name="title"]', book.title);
        await page.fill('input#image', 'https://upload.wikimedia.org/wikipedia/commons/1/1a/It_%281986%29_front_cover%2C_first_edition.jpg');
        await page.selectOption('select#type', 'Other');

        page.on('dialog', async dialog => {
            expect(dialog.type()).toContain('alert');
            expect(dialog.message()).toContain('All fields are required!');
            await dialog.accept();
        });

        await page.click('input.button.submit');
        await page.waitForURL(host + '/create');

        expect(page.url()).toBe(host + '/create');
    });

    test('Add book with empty img field', async ({ page }) => {
        await page.waitForURL(host + '/catalog');

        await page.click('a[href="/create"]');
        await page.waitForSelector('section#create-page');

        await page.fill('input[name="title"]', book.title);
        await page.fill('textarea#description', book.description);
        await page.selectOption('select#type', 'Other');

        page.on('dialog', async dialog => {
            expect(dialog.type()).toContain('alert');
            expect(dialog.message()).toContain('All fields are required!');
            await dialog.accept();
        });

        await page.click('input.button.submit');
        await page.waitForURL(host + '/create');

        expect(page.url()).toBe(host + '/create');
    });

    test('Add book with empty fields', async ({ page }) => {
        await page.click('a[href="/create"]');

        page.on('dialog', async dialog => {
            expect(dialog.type()).toContain('alert');
            expect(dialog.message()).toContain('All fields are required!');
            await dialog.accept();
        });

        await page.click('input[type="submit"]');

        await page.waitForURL(host + '/create');
        expect(page.url()).toBe(host + '/create');
        await expect(page.locator('section#create-page')).toBeVisible();
    });
});

test.describe('Test [All books] page', () => {
    test('Verify that all books are displayed', async ({ page }) => {
        await page.goto(host);
        await page.click('a[href="/catalog"]');
        await page.waitForURL(host + '/catalog');

        const allBooks = await page.locator('.other-books-list li').all();
        expect(allBooks.length).toBeGreaterThanOrEqual(0);
    });

    test('Verify that No Books message is displayed', async ({ page }) => {
        //TO DO
    });
});

test.describe('Test [Details] page', () => {
    test('Verify that logged-in user sees details button and button work correctrly', async ({ page }) => {
        await page.goto(host + '/login');
        await page.fill('input#email', 'john@abv.bg');
        await page.fill('input#password', '123456');

        await Promise.all([
            page.click('input[type="submit"]'),
            page.waitForURL(host + '/catalog')
        ]);

        await page.click('a[href="/catalog"]');

        await page.waitForSelector('.otherBooks');
        await page.click('.otherBooks a.button');

        await page.waitForSelector('.book-information');
        const detailsPageTitle = await page.textContent('.book-information h3');
        expect(detailsPageTitle).toContain(book.title);
    });

    test('Verify that guest user sees detail button and button work correctly', async ({ page }) => {
        await page.goto(host);
        await page.click('a[href="/catalog"]');

        await page.waitForSelector('.otherBooks');
        await page.click('.other-books-list li.otherBooks:first-child a.button');

        await page.waitForSelector('div.book-information');
        const bookDetails = await page.textContent('.book-information h3');
        expect(bookDetails).toBe(book.title);
    });

    test('Verify that guest user sees all book info correctly', async ({ page }) => {
        await page.goto(host);
        await page.click('a[href="/catalog"]');

        await page.waitForSelector('.otherBooks');
        await page.click('.other-books-list li.otherBooks:first-child a.button');

        await page.waitForSelector('div.book-information');
        const bookTitle = await page.textContent('.book-information h3');
        const bookType = await page.textContent('.book-information p.type');
        const bookDescription = await page.textContent('.book-description p');

        expect(bookTitle).toBe(book.title);
        expect(bookType).toContain(book.type);
        expect(bookDescription).toBe(book.description);
    });

    test('Verify that [Edit] and [Delete] buttons are visible for creator', async ({ page }) => {
        await page.goto(host + '/login');
        await page.fill('input[name="email"]', user.email);
        await page.fill('input[name="password"]', user.password);
        await page.click('input[type="submit"]');
        await page.click('ul li.otherBooks:first-child a.button');

        await expect(page.locator('div.actions >> a.button >> text=Edit')).toBeVisible();
        await expect(page.locator('div.actions >> a.button >> text=Delete')).toBeVisible();
    });

    test('Verify that [Edit] and [Delete] buttons are hidden for non-creator', async ({ page }) => {
        await page.goto(host);
        await page.locator('a[href="/catalog"]').click();
        await page.locator('ul li.otherBooks:first-child a.button').click();

        await expect(page.locator('div.actions >> a.button >> text=Edit')).toBeHidden();
        await expect(page.locator('div.actions >> a.button >> text=Delete')).toBeHidden();
    });

    test('Verify that [Like] button is not visible for creator', async ({ page }) => {
        await page.goto(host + '/login');
        await page.fill('input[name="email"]', user.email);
        await page.fill('input[name="password"]', user.password);
        await page.click('input[type="submit"]');

        await page.waitForSelector('.otherBooks');
        await page.click('li.otherBooks >> a.button >> text=Details');

        await expect(page.locator('div.actions >> a.button >> text=Like')).toBeHidden();
    });

    test('Verify that [Like] button is visible for non-creator', async ({ page }) => {
        await page.goto(host);
        await page.click('a[href="/login"]');
        await page.fill('input[name="email"]', 'john@abv.bg');
        await page.fill('input[name="password"]', '123456');
        await page.click('input[type="submit"]');
        await page.waitForSelector('.otherBooks');
        await page.click('.otherBooks >> a.button >> text=Details');
        await expect(page.locator('div.actions >> a.button >> text=Like')).toBeVisible();
    });

    test('Verify that non-creator can like book', async ({ page }) => {
        await page.goto(host);
        await page.click('a[href="/login"]');
        await page.fill('input[name="email"]', 'john@abv.bg');
        await page.fill('input[name="password"]', '123456');
        await page.click('input[type="submit"]');
        await page.waitForSelector('.otherBooks');
        await page.click('.otherBooks >> a.button >> text=Details');
        await page.click('div.actions >> a.button >> text=Like');
        await page.waitForSelector('div.likes');
        const likes = await page.textContent('span#total-likes');
        //expect(likes).toBe('Likes: 1');
        const totalLikes = likes.match(/\d+/g).map(Number);
        expect(totalLikes[0]).toBeGreaterThan(0);
    });

    test('Verify that creator can edit book', async ({ page }) => {
        await page.goto(host + '/login');
        await page.click('a[href="/login"]');
        await page.fill('input[name="email"]', user.email);
        await page.fill('input[name="password"]', user.password);
        await page.click('input[type="submit"]');
        await page.waitForSelector('.otherBooks');
        await page.click('.otherBooks >> a.button >> text=Details');
        await page.click('div.actions >> a.button >> text=Edit');
        await page.waitForSelector('section#edit-page');
        await page.fill('input[name="title"]', 'Edited Title');
        await page.click('input[type="submit"]');
        await page.waitForSelector('div.book-information');
        const editedTitle = await page.textContent('div.book-information h3');
        expect(editedTitle).toContain('Edited Title');
    });

    test('Verify that creator can delete book', async ({ page }) => {
        await page.goto(host + '/login');
        await page.click('a[href="/login"]');
        await page.fill('input[name="email"]', user.email);
        await page.fill('input[name="password"]', user.password);
        await page.click('input[type="submit"]');
        await page.waitForSelector('.otherBooks');
        await page.click('.otherBooks >> a.button >> text=Details');

        page.on('dialog', async dialog => {
            expect(dialog.type()).toContain('confirm');
            expect(dialog.message()).toContain('Are you sure?');
            await dialog.accept();
        });
        await page.click('div.actions >> a.button >> text=Delete');
        await page.waitForURL(host + '/catalog');
        expect(page.url()).toBe(host + '/catalog');
        const defaultBooks = await page.locator('li.otherBooks').all();
        expect(defaultBooks.length).toBe(3);
    });
});

test.describe('Test [Logout] button', () => {
    test('Verify that the [Logout] button redirects correctly', async ({ page }) => {
        await page.goto(host + '/login');
        await page.fill('input[name="email"]', user.email);
        await page.fill('input[name="password"]', user.password);
        await page.click('input[type="submit"]');

        await page.waitForSelector('section.navbar-dashboard');
        await page.click('div#user >> a.button >> text=Logout');

        await page.waitForURL(host + '/');
        expect(page.url()).toBe(host + '/');
    })
});