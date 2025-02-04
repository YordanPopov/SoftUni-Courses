const { test, expect } = require('@playwright/test');

const host = "http://localhost:3000";

const user = {
    email: "peter@abv.bg",
    password: "123456"
};

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
    let rnd = Math.floor(Math.random() * 101);

    test.beforeEach('Open login page URL and fill user data', async ({ page }) => {
        await page.goto(host + '/login');
        await page.fill('input[name="email"]', user.email);
        await page.fill('input[name="password"]', user.password);
        page.click('input[type="submit"]');
    });

    test.only('Submit the form with valid data', async ({ page }) => {
        await page.waitForURL(host + '/catalog');

        await page.click('a[href="/create"]');
        await page.waitForSelector('section#create-page');

        await page.fill('input#title', `Some-Title-${rnd}`);
        await page.fill('textarea#description', `Some-Description-${rnd}`);
        await page.fill('input#image', 'https://upload.wikimedia.org/wikipedia/commons/1/1a/It_%281986%29_front_cover%2C_first_edition.jpg');
        await page.selectOption('select#type', 'Other');
        await page.click('input.button.submit');

        await page.waitForURL(host + '/catalog');
        expect(page.url()).toBe(host + '/catalog');
        await expect(page.locator(`h3 >> text=Some-Title-${rnd}`)).toBeVisible();
    });

    test('Add book with empty title field', async ({ page }) => {
        await page.waitForURL(host + '/catalog');

        await page.click('a[href="/create"]');
        await page.waitForSelector('section#create-page');

        await page.fill('textarea#description', `Some-Description-${rnd}`);
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

        await page.fill('input[name="title"]', `Some-Title-${rnd}`);
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

        await page.fill('input[name="title"]', `Some-Title-${rnd}`);
        await page.fill('textarea#description', `Some-Description-${rnd}`);
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
});
