const { test, expect } = require('@playwright/test');

test.describe('NavBar for guest users', () => {
    test.beforeEach('', async ({ page }) => {
        await page.goto('http://localhost:3000');
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
        await page.goto('http://localhost:3000/login');
        await page.fill('input[name="email"]', 'peter@abv.bg');
        await page.fill('input[name="password"]', '123456');
        await page.click('input[type="submit"]');
    });

    test('Verify that [All Books] link is visible after user login', async ({ page }) => {
        await page.waitForSelector('nav.navbar');

        const allBooksLink = await page.$('a[href="/catalog"]');

        expect(await allBooksLink.isVisible()).toBeTruthy();
    });

    test('Verify that [My Books] link is visible after user login', async ({ page }) => {
        await page.waitForSelector('nav.navbar');

        const MyBookLink = await page.$('a[href="/profile"]');

        expect(await MyBookLink.isVisible()).toBeTruthy();
    });

    test('Verify that [Add Book] link is visible after user login', async ({ page }) => {
        await page.waitForSelector('nav.navbar');

        const AddBookLink = await page.$('a[href="/create"]');

        expect(await AddBookLink.isVisible()).toBeTruthy();
    });

    test('Verify that [Logout] button is visible after user login', async ({ page }) => {
        await page.waitForSelector('nav.navbar');

        const logoutBtn = await page.$('#logoutBtn');

        expect(await logoutBtn.isVisible()).toBeTruthy();
    });

    test('Verify that the email address of user is visible', async ({ page }) => {
        await page.waitForSelector('nav.navbar');

        const emailAddress = await page.$eval('#user span',
            email => email.textContent
        );

        expect(emailAddress).toContain('Welcome, peter@abv.bg');
    });
});

test.describe('Test Login page', () => {
    test.beforeEach('Open login page URL', async ({ page }) => {
        await page.goto('http://localhost:3000/login');
    });

    test('Submit the form with valid credentials', async ({ page }) => {
        await page.fill('input[name="email"]', 'peter@abv.bg');
        await page.fill('input[name="password"]', '123456');
        await page.click('input[type="submit"]');

        await page.$('a[href="/catalog"]');
        expect(page.url()).toBe('http://localhost:3000/catalog');
    });

    test('Submit the form with empty input fields', async ({ page }) => {
        await page.click('input[type="submit"]');

        page.on('dialog', async dialog => {
            expect(dialog.type()).toContain('alert');
            expect(dialog.message()).toContain('All fields are required!');
            await dialog.accept();
        });

        await page.waitForSelector('section#login-page.login');
        expect(page.url()).toBe('http://localhost:3000/login');
    });

    test('Submit the form with empty email input field', async ({ page }) => {
        await page.fill('input[name="password"]', '123456');
        await page.click('input[type="submit"]');

        page.on('dialog', async dialog => {
            expect(dialog.type()).toContain('alert');
            expect(dialog.message()).toContain('All fields are required!');
            await dialog.accept();
        });

        await page.waitForSelector('section#login-page.login');
        expect(page.url()).toBe('http://localhost:3000/login');
    });

    test('Submit the form with empty password input field', async ({ page }) => {
        await page.fill('input[name="email"]', 'peter@abv.bg');
        await page.click('input[type="submit"]');

        page.on('dialog', async dialog => {
            expect(dialog.type()).toContain('alert');
            expect(dialog.message()).toContain('All fields are required!');
            await dialog.accept();
        });

        await page.waitForSelector('section#login-page.login');
        expect(page.url()).toBe('http://localhost:3000/login');
    });
});

test.describe('Test Register page', () => {
    test.beforeEach('Open Register page URL', async ({ page }) => {
        await page.goto('http://localhost:3000/register');
    });

    test('Submit the form with valid credentials', async ({ page }) => {
        const rnd = Math.floor(Math.random() * 100);

        await page.fill('input#email', `testUser_${rnd}@abc.bg`);
        await page.fill('input#password', '123456');
        await page.fill('input#repeat-pass', '123456');
        await page.click('input[type="submit"]');

        const logoutBtn = await page.$('a#logoutBtn');
        const loginBtnIsVisible = await logoutBtn.isVisible();

        expect(page.url()).toBe('http://localhost:3000/catalog');
        expect(loginBtnIsVisible).toBeTruthy();
    });

    test('Sumbit the form with empty fields', async ({ page }) => {
        await page.click('input[type="submit"]');

        page.on('dialog', async dialog => {
            expect(dialog.type()).toContain('alert');
            expect(dialog.message()).toContain('All fields are required!');
            await dialog.accept();
        })

        const regSection = await page.$('section#register-page');
        expect(await regSection.isVisible()).toBeTruthy();
        expect(page.url()).toBe('http://localhost:3000/register');
    });

    test('Sumbit the form with empty email field', async ({ page }) => {
        await page.fill('input#password', '123456');
        await page.fill('input#repeat-pass', '123456');
        await page.click('input[type="submit"]');

        page.on('dialog', async dialog => {
            expect(dialog.type()).toContain('alert');
            expect(dialog.message()).toContain('All fields are required!');
            await dialog.accept();
        })

        const regSection = await page.$('section#register-page');
        expect(await regSection.isVisible()).toBeTruthy();
        expect(page.url()).toBe('http://localhost:3000/register');
    });

    test('Sumbit the form with empty password field', async ({ page }) => {
        const rnd = Math.floor(Math.random() * 100);

        await page.fill('input#email', `testUser_${rnd}@abc.bg`);
        await page.fill('input#repeat-pass', '123456');
        await page.click('input[type="submit"]');

        page.on('dialog', async dialog => {
            expect(dialog.type()).toContain('alert');
            expect(dialog.message()).toContain('All fields are required!');
            await dialog.accept();
        })

        const regSection = await page.$('section#register-page');
        expect(await regSection.isVisible()).toBeTruthy();
        expect(page.url()).toBe('http://localhost:3000/register');
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
        expect(page.url()).toBe('http://localhost:3000/register');
    });

    test('Submit the form with different confirm password', async ({ page }) => {
        const rnd = Math.floor(Math.random() * 100);

        await page.fill('input#email', `testUser_${rnd}@abc.bg`);
        await page.fill('input#password', '123456');
        await page.fill('input#repeat-pass', '654321');
        await page.click('input[type="submit"]');

        page.on('dialog', async dialog => {
            expect(dialog.type()).toContain('alert');
            expect(dialog.message()).toContain('Passwords don\'t match!');
            await dialog.accept();
        });

        const regSection = await page.$('section#register-page');
        expect(await regSection.isVisible()).toBeTruthy();
        expect(page.url()).toBe('http://localhost:3000/register');

    });
});