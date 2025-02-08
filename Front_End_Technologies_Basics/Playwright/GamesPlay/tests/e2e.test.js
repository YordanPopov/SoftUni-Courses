const { expect, test, chromium, beforeAll, afterAll, beforeEach, afterEach, describe } = require('@playwright/test');

const host = 'http://localhost:3000';

let browser;
let context;
let page;

let user = {
    email: '',
    pass: '123456',
    confirmPass: '123456'
}

let game = {
    title: '',
    category: '',
    id: '',
    maxLevel: '99',
    imageUrl: 'https://logos-world.net/wp-content/uploads/2023/07/Doom-Logo.png',
    summary: 'Test_Summary'
}

describe('e2e tests', () => {
    beforeAll(async () => {
        browser = await chromium.launch();
    });

    afterAll(async () => {
        await browser.close();
    });

    beforeEach(async () => {
        context = await browser.newContext();
        page = await context.newPage();
    });

    afterEach(async () => {
        await page.close();
        await context.close();
    });

    describe('Authentication', async () => {
        test('Register with valid data', async ({ page }) => {
            await page.goto(host);
            await page.click('a[href="/register"]');
            await page.waitForSelector('form#register');

            let random = Math.floor(Math.random() * 101);
            user.email = `testUser${random}@email.com`;

            await page.fill('input[name="email"]', user.email);
            await page.fill('input[name="password"]', user.pass);
            await page.fill('input[name="confirm-password"]', user.confirmPass);
            await page.click('input.btn.submit');

            await expect(page).toHaveURL(host + '/');
            await expect(page.locator('nav a[href="/logout"]')).toBeVisible();
        });

        test('Register with empty fields', async ({ page }) => {
            await page.goto(host);
            await page.click('a[href="/register"]');
            await page.waitForSelector('form#register');

            page.on('dialog', async dialog => {
                expect(dialog.type()).toContain('alert');
                expect(dialog.message()).toContain('No empty fields are allowed and confirm password has to match password!');
                dialog.accept();
            });

            await page.click('input.btn.submit');
            await expect(page).toHaveURL(host + '/register');
        });

        test('Login with valid credentials', async ({ page }) => {
            await page.goto(host);
            await page.click('div#guest a[href="/login"]');
            await page.waitForSelector('form#login');
            await page.fill('input[name="email"]', user.email);
            await page.fill('input[name="password"]', user.pass);
            await page.click('input.btn.submit');

            await expect(page.locator('nav a[href="/logout"]')).toBeVisible();
            await expect(page).toHaveURL(host + '/');
        });

        test('Login with empty fields', async ({ page }) => {
            await page.goto(host);
            await page.click('a[href="/login"]');
            await page.waitForSelector('form#login');

            page.on('dialog', async dialog => {
                expect(dialog.type()).toContain('alert');
                expect(dialog.message()).toContain('Unable to log in!');
                dialog.accept();
            });
            await page.click('input.btn.submit');

            await expect(page).toHaveURL(host + '/login');
        });

        test('Logout from the application', async ({ page }) => {
            await page.goto(host);
            await page.click('a[href="/login"]');
            await page.waitForSelector('form#login');
            await page.fill('input[name="email"]', user.email);
            await page.fill('input[name="password"]', user.pass);
            await page.click('input.btn.submit');

            await expect(page).toHaveURL(host + '/');
            await page.click('a[href="/logout"]');
            await expect(page.locator('a >> text=Login')).toBeVisible();
        })
    });
});