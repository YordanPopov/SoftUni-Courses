const { test, describe, beforeEach, afterEach, beforeAll, afterAll, expect } = require('@playwright/test');
const { chromium } = require('playwright');

const host = 'http://localhost:3000';

let browser;
let context;
let page;

let user = {
    email: "",
    password: "123456",
    confirmPass: "123456",
};

let bookTitle = "";

describe("e2e tests", () => {
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


    describe("authentication", () => {
        test('Registration with valid data', async () => {
            await page.goto(host);
            await page.click('a >> text=Register');
            await page.waitForSelector('form.register-form');

            let rnd = Math.floor(Math.random() * 1001);
            user.email = `testUser_${rnd}@email.com`;

            await page.locator('input[name="email"]').fill(user.email);
            await page.locator('input[name="password"]').fill(user.password);
            await page.locator('input[name="conf-pass"]').fill(user.confirmPass);
            await page.click('button[type="submit"]');

            await expect(page).toHaveURL(host + '/');
            await expect(page.locator('a >> text=Logout')).toBeVisible();
        });

        test('Login with valid data', async () => {
            await page.goto(host);
            await page.click('a >> text=Login');
            await page.waitForSelector('form.login-form');
            await page.locator('input[name="email"]').fill(user.email);
            await page.locator('input[name="password"]').fill(user.password);
            await page.click('button[type="submit"]');

            await expect(page).toHaveURL(host + '/');
            await expect(page.locator('a >> text=Logout')).toBeVisible();
        });

        test('Logout from the application', async () => {
            await page.goto(host);
            await page.click('a >> text=Login');
            await page.waitForSelector('form.login-form');
            await page.locator('input[name="email"]').fill(user.email);
            await page.locator('input[name="password"]').fill(user.password);
            await page.click('button[type="submit"]');

            await page.click('a >> text=Logout');
            await page.waitForSelector('a >> text=Login');

            await expect(page).toHaveURL(host + '/');
            await expect(page.locator('a >> text=Login')).toBeVisible();

        });
    });

    describe("navbar", () => {
        test('Navigation bar for logged-in user', async () => {
            await page.goto(host);
            await page.click('a >> text=Login');
            await page.waitForSelector('form.login-form');
            await page.locator('input[name="email"]').fill(user.email);
            await page.locator('input[name="password"]').fill(user.password);
            await page.click('button[type="submit"]');

            await expect(page.locator('a >> text=Home')).toBeVisible();
            await expect(page.locator('a >> text=Collection')).toBeVisible();
            await expect(page.locator('a >> text=Search')).toBeVisible();
            await expect(page.locator('a >> text=Create Book')).toBeVisible();
            await expect(page.locator('a >> text=Logout')).toBeVisible();
            await expect(page.locator('a >> text=Login')).toBeHidden();
            await expect(page.locator('a >> text=Register')).toBeHidden();
        });

        test('Navigation bar for guest user', async () => {
            await page.goto(host);

            await expect(page.locator('a >> text=Home')).toBeVisible();
            await expect(page.locator('a >> text=Collection')).toBeVisible();
            await expect(page.locator('a >> text=Search')).toBeVisible();
            await expect(page.locator('a >> text=Login')).toBeVisible();
            await expect(page.locator('a >> text=Register')).toBeVisible();
            await expect(page.locator('a >> text=Create Book')).toBeHidden();
            await expect(page.locator('a >> text=Logout')).toBeHidden();
        });
    });

    describe("CRUD", () => {
        beforeEach(async () => {
            await page.goto(host);
            await page.click('a >> text=Login');
            await page.waitForSelector('form.login-form');
            await page.locator('input[name="email"]').fill(user.email);
            await page.locator('input[name="password"]').fill(user.password);
            await page.click('button[type="submit"]');
        });

        test('Create a book with valid data', async () => {
            await page.click('a >> text=Create Book');
            await page.waitForSelector('form.book-form');

            let rnd = Math.floor(Math.random() * 1001);
            bookTitle = `testTitle${rnd}`;

            await page.locator('#title').fill(bookTitle);
            await page.locator('#coverImage').fill('https://upload.wikimedia.org/wikipedia/commons/1/1a/It_%281986%29_front_cover%2C_first_edition.jpg');
            await page.locator('#year').fill('1969');
            await page.locator('#author').fill('someAuthor');
            await page.locator('#genre').fill('someGenre');
            await page.locator('textarea[name="description"]').fill('someDescription');
            await page.click('button.save-btn');

            await expect(page).toHaveURL(host + '/collection');
            await expect(page.locator('div.book .book-details h2', { hasText: bookTitle })).toHaveCount(1);
        });

        test('Edit a book with valid data', async () => {
            await page.click('a >> text=Search');
            await page.locator('input[name="search"]').fill(bookTitle);
            await page.click('button[type="submit"]');
            await page.locator('li >> a', { hasText: bookTitle }).first().click();
            await page.click('div.actions a.edit-btn');
            await page.waitForSelector('form.book-form');

            bookTitle += '-edited';
            await page.locator('#title').fill(bookTitle);
            await page.click('button.save-btn');

            await expect(page.locator('div.book-info h2')).toHaveText(bookTitle);
        });

        test('Delete a book', async () => {
            await page.click('a >> text=Search');
            await page.locator('input[name="search"]').fill(bookTitle);
            await page.click('button[type="submit"]');
            await page.locator('li >> a', { hasText: bookTitle }).first().click();
            await page.click('div.actions a.delete-btn');

            await expect(page).toHaveURL(host + '/collection');
            await expect(page.locator('.book .book-details h2', { hasText: bookTitle })).toHaveCount(0);
        });
    });
});