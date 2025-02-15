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

let meme = {
    title: '',
    id: "",
    description: 'This is meme for testing',
    img: "../images/1.png"
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

        test('Registration with empty fields', async () => {
            await page.goto(host);
            await page.click('nav >> text=Register');
            await page.waitForSelector('#register-form');
            await page.click('input[type="submit"]');

            await expect(page.locator('#errorBox span', { hasText: 'All fields are required!' })).toBeVisible();
            await expect(page).toHaveURL(host + '/register');
        });

        test('Registration with different confirm password', async () => {
            await page.goto(host);
            await page.click('text=Register');
            await page.waitForSelector('form#register-form');

            await page.fill('#username', 'testUser1111');
            await page.fill('#email', 'testUser1111@email.com');
            await page.fill('#password', '111111');
            await page.fill('#repeatPass', '123456');
            await page.check('input[name="gender"][value="female"]');
            page.click('input[type="submit"]');

            await expect(page.locator('#errorBox span', { hasText: 'All fields are required!' })).toBeVisible();
            await expect(page).toHaveURL(host + '/register');
        });

        test('Registration with existent user', async () => {
            await page.goto(host);
            await page.click('text=Register');
            await page.waitForSelector('form#register-form');

            await page.fill('#username', user.username);
            await page.fill('#email', user.email);
            await page.fill('#password', user.password);
            await page.fill('#repeatPass', user.confirmPass);
            await page.check('input[name="gender"][value="female"]');
            page.click('input[type="submit"]');

            await expect(page.locator('#errorBox span', { hasText: 'Existing user or confirm password does not match!' })).toBeVisible();
            await expect(page).toHaveURL(host + '/register');
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

        test('Login with empty fields', async () => {
            await page.goto(host);
            await page.click('nav >> text=Login');
            await page.waitForSelector('#login-form');

            await page.click('input[type="submit"]');
            await expect(page.locator('#errorBox >> span', { hasText: 'No empty fields' })).toBeVisible();
            await expect(page).toHaveURL(host + '/login');
        });

        test('Login with non-existent email', async () => {
            await page.goto(host);
            await page.click('a.button >> text=Login');
            await page.waitForSelector('#login-form');

            await page.fill('#email', 'non-existentUser@email.com');
            await page.fill('#password', '123456');
            await page.click('input[type="submit"]');

            await expect(page.locator('#errorBox span'), { hasText: 'Email or password don\'t match' }).toBeVisible();
            await expect(page).toHaveURL(host + '/login');
        });

        test('Login with wrong password', async () => {
            await page.goto(host);
            await page.click('a.button >> text=Login');
            await page.waitForSelector('#login-form');

            await page.fill('#email', user.email);
            await page.fill('#password', '654321');
            await page.click('input[type="submit"]');

            await expect(page.locator('#errorBox span'), { hasText: 'Email or password don\'t match' }).toBeVisible();
            await expect(page).toHaveURL(host + '/login');
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

        test('Navigation for Guest user', async ({ page }) => {
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
        beforeEach(async () => {
            await page.goto(host);
            await page.click('nav >> a >> text=Login');
            await page.waitForSelector('#login-form');
            await page.fill('#email', user.email);
            await page.fill('#password', user.password);
            await page.click('input[type="submit"]');

            await page.waitForURL(host + '/catalog');
        });

        test('Create a meme with valid data', async () => {
            await page.click('nav >> a >> text=Create Meme');
            await page.waitForSelector('#create-form');

            let rnd = Math.floor(Math.random() * 1001);
            meme.title = `testMeme${rnd}`;

            await page.fill('#title', meme.title);
            await page.fill('#description', meme.description);
            await page.fill('#imageUrl', meme.img);

            let [res] = await Promise.all([
                page.waitForResponse(res => res.url().includes('/data/memes') && res.status() === 200),
                page.click('input[type="submit"]')
            ]);

            expect(res.ok()).toBeTruthy();
            let memeData = await res.json();
            expect(memeData.title).toBe(meme.title);
            expect(memeData.description).toBe(meme.description);
            expect(memeData.imageUrl).toBe(meme.img);

            await expect(page).toHaveURL(host + '/catalog');
            await expect(page.locator('.meme .card .info p', { hasText: meme.title })).toHaveCount(1);
        });

        test('Edit a meme with valid data', async () => {
            await page.click('nav >> a >> text=My Profile');
            await page.locator('.user-meme .button').first().click();
            await page.click('.meme-description >> a >> text=Edit');
            await page.waitForSelector('#edit-form');

            meme.id = page.url().split('/').pop();
            meme.title += '-Edited';
            await page.fill('#title', meme.title);

            let [res] = await Promise.all([
                page.waitForResponse(res => res.url().includes('/data/memes') && res.status() === 200),
                page.click('input[type="submit"]')
            ]);

            expect(res.ok()).toBeTruthy();
            let memeData = await res.json();
            expect(memeData.title).toBe(meme.title);

            await expect(page).toHaveURL(host + `/details/${meme.id}`);
            await expect(page.locator('#meme-details h1')).toHaveText(`Meme Title: ${meme.title}s`);
        });

        test('Delete a meme', async () => {
            await page.click('nav >> text=My Profile');
            await page.locator('.user-meme .button').first().click();

            let [res] = await Promise.all([
                page.waitForResponse(res => res.url().includes('/data/memes') && res.status() === 200),
                page.click('button >> text=Delete')
            ]);

            expect(res.ok()).toBeTruthy();
            await expect(page).toHaveURL(host + '/catalog');
            await expect(page.locator('.meme .card .info p', { hasText: meme.title })).toHaveCount(0);
        });
    });
});