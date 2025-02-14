const { test, describe, beforeEach, afterEach, beforeAll, afterAll, expect } = require('@playwright/test');
const { chromium } = require('playwright');

const host = 'http://localhost:3000'; // Application host (NOT service host - that can be anything)

let browser;
let context;
let page;

let user = {
    username: "",
    email: "",
    password: "123456",
    confirmPass: "123456",
};

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
            await page.click('text=Register');
            await page.waitForSelector('form#register-form');

            let rnd = Math.floor(Math.random() * 1001);
            user.email = `testUser${rnd}@email.com`;
            user.username = `testUser${rnd}`;

            await page.fill('#username', user.username);
            await page.fill('#email', user.email);
            await page.fill('#password', user.password);
            await page.fill('#repeatPass', user.confirmPass);
            await page.check('input[name="gender"][value="female"]');

            let [res] = await Promise.all([
                page.waitForResponse(res => res.url().includes('/users/register') && res.status() === 200),
                page.click('input[type="submit"]')
            ]);

            expect(res.ok()).toBeTruthy();
            let userData = await res.json();

            expect(userData.email).toBe(user.email);
            expect(userData.password).toBe(user.password);
            await expect(page).toHaveURL(host + '/catalog');
            await expect(page.locator('.profile >> span')).toHaveText(`Welcome, ${user.email}`);
            await expect(page.locator('a >> text=Logout')).toBeVisible();
        });

        test('Login with valid data', async () => {
            await page.goto(host);
            await page.click('text=Login');
            await page.waitForSelector('form#login-form');
            await page.fill('#email', user.email);
            await page.fill('#password', user.password);

            let [res] = await Promise.all([
                page.waitForResponse(res => res.url().includes('/users/login') && res.status() === 200),
                page.click('input[type="submit"]')
            ]);

            expect(res.ok()).toBeTruthy();
            let userData = await res.json();
            expect(userData.email).toBe(user.email);
            expect(user.password).toBe(user.password);

            await expect(page).toHaveURL(host + '/catalog');
            await expect(page.locator('.profile >> span')).toHaveText(`Welcome, ${user.email}`);
            await expect(page.locator('a >> text=Logout')).toBeVisible();
        });

        test('Logout from the application', async () => {
            await page.goto(host);
            await page.click('text=Login');
            await page.waitForSelector('form#login-form');
            await page.fill('#email', user.email);
            await page.fill('#password', user.password);
            await page.click('input[type="submit"]');

            let [res] = await Promise.all([
                page.waitForResponse(res => res.url().includes('/users/logout') && res.status() === 204),
                page.click('a >> text=Logout')
            ]);

            expect(res.ok()).toBeTruthy();
            await page.waitForSelector('a >> text=Login');
            await expect(page).toHaveURL(host + '/');
        });
    });

    describe("navbar", () => {
        test('Navigation for Logged-in user', async () => {
            await page.goto(host);
            await page.click('text=Login');
            await page.waitForSelector('form#login-form');
            await page.fill('#email', user.email);
            await page.fill('#password', user.password);
            await page.click('input[type="submit"]');

            await expect(page.locator('a >> text=All Memes')).toBeVisible();
            await expect(page.locator('a >> text=Create Meme')).toBeVisible();
            await expect(page.locator('a >> text=My Profile')).toBeVisible();
            await expect(page.locator('a >> text=Logout')).toBeVisible();
            await expect(page.locator('a >> text=Login')).toBeHidden();
            await expect(page.locator('a >> text=Register')).toBeHidden();
        });

        test('Navigation for Guest user', async () => {
            await page.goto(host);
            await expect(page.locator('a >> text=Create Meme')).toBeHidden();
            await expect(page.locator('a >> text=My Profile')).toBeHidden();
            await expect(page.locator('a >> text=Logout')).toBeHidden();
            await expect(page.locator('a >> text=All Memes')).toBeVisible();
            await expect(page.locator('a >> text=Home Page')).toBeVisible();
            await expect(page.locator('.profile >> a >> text=Login')).toBeVisible();
            await expect(page.locator('.profile >> a >> text=Register')).toBeVisible();
        });
    });

    describe("CRUD", () => {

    });
});