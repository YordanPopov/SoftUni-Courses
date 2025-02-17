const { test, describe, beforeEach, afterEach, beforeAll, afterAll, expect } = require('@playwright/test');
const { chromium } = require('playwright');

const host = 'http://localhost:3000'; // Application host (NOT service host - that can be anything)

let browser;
let context;
let page;

let user = {
    email: "",
    password: "123456",
    confirmPass: "123456",
};

let book = {
    title: "",
    description: "someDescription",
    imageUrl: "https://upload.wikimedia.org/wikipedia/commons/1/1a/It_%281986%29_front_cover%2C_first_edition.jpg",
    type: "Other"
}

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
            await page.waitForSelector('form#register-form');

            let random = Math.floor(Math.random() * 1001);
            user.email = `testUser${random}@email.com`;

            await page.locator('#email').fill(user.email);
            await page.locator('#password').fill(user.password);
            await page.locator('#repeat-pass').fill(user.confirmPass);

            let [response] = await Promise.all([
                page.waitForResponse(res => res.url().includes('/users/register') && res.status() === 200),
                page.click('input[type="submit"]')
            ]);

            expect(response.ok()).toBeTruthy();

            const userData = await response.json();
            expect(userData.email).toEqual(user.email);
            expect(userData.password).toEqual(user.password);

            await expect(page).toHaveURL(host + '/');
            await expect(page.locator('#user span')).toHaveText(`Welcome, ${user.email}`);
            await expect(page.locator('a >> text=Logout')).toBeVisible();
        });

        test('Login with valid data', async () => {
            await page.goto(host);
            await page.click('a >> text=Login');
            await page.waitForSelector('form#login-form');
            await page.locator('#email').fill(user.email);
            await page.locator('#password').fill(user.password);

            let [response] = await Promise.all([
                page.waitForResponse(res => res.url().includes('/users/login') && res.status() === 200),
                page.click('input[type="submit"]')
            ]);

            expect(response.ok()).toBeTruthy();

            const userData = await response.json();
            expect(userData.email).toEqual(user.email);
            expect(userData.password).toEqual(user.password);

            await expect(page).toHaveURL(host + '/');
            await expect(page.locator('#user span')).toHaveText(`Welcome, ${user.email}`);
            await expect(page.locator('a >> text=Logout')).toBeVisible();
        });

        test('Logout from the application', async () => {
            await page.goto(host);
            await page.click('a >> text=Login');
            await page.waitForSelector('form#login-form');
            await page.locator('#email').fill(user.email);
            await page.locator('#password').fill(user.password);
            await page.click('input[type="submit"]');

            let [response] = await Promise.all([
                page.waitForResponse(res => res.url().includes('/users/logout') && res.status() === 204),
                page.click('a >> text=Logout')
            ]);

            expect(response.ok()).toBeTruthy();

            await page.waitForSelector('a >> text=Login');
            await expect(page).toHaveURL(host + '/');
        });
    });

    describe("navbar", () => {
        test('Navigation bar for logged-in user', async () => {
            await page.goto(host);
            await page.click('a >> text=Login');
            await page.waitForSelector('form#login-form');
            await page.locator('#email').fill(user.email);
            await page.locator('#password').fill(user.password);
            await page.click('input[type="submit"]');

            await expect(page.locator('a >> text=Dashboard')).toBeVisible();
            await expect(page.locator('a >> text=My Books')).toBeVisible();
            await expect(page.locator('a >> text=Add Book')).toBeVisible();
            await expect(page.locator('a >> text=Logout')).toBeVisible();
            await expect(page.locator('a >> text=Login')).toBeHidden();
            await expect(page.locator('a >> text=Register')).toBeHidden();
        });

        test('Navigation bar for guest user', async () => {
            await page.goto(host);

            await expect(page.locator('a >> text=My Books')).toBeHidden();
            await expect(page.locator('a >> text=Add Book')).toBeHidden();
            await expect(page.locator('a >> text=Logout')).toBeHidden();
            await expect(page.locator('a >> text=Dashboard')).toBeVisible();
            await expect(page.locator('a >> text=Login')).toBeVisible();
            await expect(page.locator('a >> text=Register')).toBeVisible();
        });
    });

    describe("CRUD", () => {
        beforeEach(async () => {
            await page.goto(host);
            await page.click('a >> text=Login');
            await page.waitForSelector('form#login-form');
            await page.locator('#email').fill(user.email);
            await page.locator('#password').fill(user.password);
            await page.click('input[type="submit"]');
        });

        test('Create a book with valid data', async () => {
            await page.click('a >> text=Add Book');
            await page.waitForSelector('form#create-form');

            let random = Math.floor(Math.random() * 1001);
            book.title = `testTitle${random}`;

            await page.locator('#title').fill(book.title);
            await page.locator('#description').fill(book.description);
            await page.locator('#image').fill(book.imageUrl);
            await page.selectOption('#type', book.type);

            let [response] = await Promise.all([
                page.waitForResponse(res => res.url().includes('/data/books') && res.status() === 200),
                page.click('input[type="submit"]')
            ]);

            expect(response.ok()).toBeTruthy();

            const bookData = await response.json();
            expect(bookData.title).toBe(book.title);
            expect(bookData.description).toBe(book.description);
            expect(bookData.imageUrl).toBe(book.imageUrl);
            expect(bookData.type).toBe(book.type);

            await expect(page).toHaveURL(host + '/');
            await expect(page.locator('li.otherBooks h3', { hasText: book.title })).toHaveCount(1);
        });

        test('Edit a book with valid data', async () => {
            await page.click('a >> text=My Books');
            await page.locator('li.otherBooks >> a >> text=Details').first().click();
            await page.click('a >> text=Edit');
            await page.waitForSelector('form#edit-form');

            book.title += '-edited';
            await page.locator('#title').fill(book.title);

            let [response] = await Promise.all([
                page.waitForResponse(res => res.url().includes('/data/books') && res.status() === 200),
                page.click('input[type="submit"]')
            ]);

            expect(response.ok()).toBeTruthy();

            const bookData = await response.json();
            expect(bookData.title).toBe(book.title);
            expect(bookData.description).toBe(book.description);
            expect(bookData.imageUrl).toBe(book.imageUrl);
            expect(bookData.type).toBe('Fiction');

            await expect(page.locator('.book-information h3')).toHaveText(book.title);
        });

        test('Delete a book', async () => {
            await page.click('a >> text=My Books');
            await page.locator('li.otherBooks >> a >> text=Details').first().click();

            let [response] = await Promise.all([
                page.waitForResponse(res => res.url().includes('/data/books') && res.status() === 200),
                page.click('a >> text=Delete')
            ]);

            expect(response.ok()).toBeTruthy();
            await expect(page.locator('li.otherBooks h3', { hasText: book.title })).toHaveCount(0);
        });
    });
})