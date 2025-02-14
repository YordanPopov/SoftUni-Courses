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

let petName = "";

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
        test('Register with valid data', async () => {
            await page.goto(host);
            await page.click('text=Register');
            await page.waitForSelector('form.registerForm');

            let rnd = Math.floor(Math.random() * 1001);
            user.email = `testUser${rnd}@email.com`;

            await page.fill('#email', user.email);
            await page.fill('#password', user.password);
            await page.fill('#repeatPassword', user.confirmPass);
            await page.click('button >> text=Register');

            await expect(page).toHaveURL(host + '/');
            await expect(page.locator('text=Logout')).toBeVisible();
        });

        test('Login with valid data', async () => {
            await page.goto(host);
            await page.click('text=Login');
            await page.waitForSelector('form.loginForm');
            await page.fill('#email', user.email);
            await page.fill('#password', user.password);
            await page.click('button >> text=Login');

            await expect(page).toHaveURL(host + '/');
            await expect(page.locator('a >> text=Logout')).toBeVisible();
        });

        test('Logout from the Application', async () => {
            await page.goto(host);
            await page.click('text=Login');
            await page.waitForSelector('form.loginForm');
            await page.fill('#email', user.email);
            await page.fill('#password', user.password);
            await page.click('button >> text=Login');

            await page.click('text=Logout');

            await expect(page).toHaveURL(host + '/');
            await expect(page.locator('a >> text=Login')).toBeVisible();
        });
    });

    describe("navbar", () => {
        test('Navigation for Logged-in user', async () => {
            await page.goto(host);
            await page.click('text=Login');
            await page.waitForSelector('form.loginForm');
            await page.fill('#email', user.email);
            await page.fill('#password', user.password);
            await page.click('button >> text=Login');

            await expect(page.locator('a >> text=Home')).toBeVisible();
            await expect(page.locator('a >> text=Dashboard')).toBeVisible();
            await expect(page.locator('a >> text=Create Postcard')).toBeVisible();
            await expect(page.locator('a >> text=Logout')).toBeVisible();

            await expect(page.locator('a >> text=Login')).toBeHidden();
            await expect(page.locator('a >> text=Register')).toBeHidden();
        });

        test('Navigation for Guest user', async () => {
            await page.goto(host);

            await expect(page.locator('a >> text=Home')).toBeVisible();
            await expect(page.locator('a >> text=Dashboard')).toBeVisible();
            await expect(page.locator('a >> text=Login')).toBeVisible();
            await expect(page.locator('a >> text=Register')).toBeVisible();

            await expect(page.locator('a >> text=Create Postcard')).toBeHidden();
            await expect(page.locator('a >> text=Logout')).toBeHidden();
        });
    });

    describe("CRUD", () => {
        beforeEach(async () => {
            await page.goto(host);
            await page.click('text=Login');
            await page.waitForSelector('form.loginForm');
            await page.fill('#email', user.email);
            await page.fill('#password', user.password);
            await page.click('button >> text=Login');
        });

        test('Create a Postcard with valid data', async () => {
            await page.click('text=Create Postcard');
            await page.waitForSelector('form.createForm');

            let rnd = Math.floor(Math.random() * 1001);
            petName = `testAnimal${rnd}`;

            await page.fill('#name', petName);
            await page.fill('#breed', 'testBreed');
            await page.fill('#age', '11');
            await page.fill('#weight', '11');
            //await page.fill('#image', 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR3HTgKkm-tBcNbiLG5eCL12nOngY_fEta2BA&s');
            await page.fill('#image', '../images/cat2.jpg');
            await page.click('button >> text=Create');

            await expect(page).toHaveURL(host + '/catalog');
            await expect(page.locator('div.animals-board >> h2.name', { hasText: petName })).toHaveCount(1);
        });

        test.skip('Edit a Postcard with valid data', async () => {
            await page.click('text=Dashboard');
            const detailsBtn = page.locator('div.animals-board', { hasText: petName })
                .locator('a >> text=Details');
            await detailsBtn.click();

            petName += '-Edited';
            await page.click('a >> text=Edit');
            await page.waitForSelector('form.editForm');
            await page.fill('#name', petName);
            await page.click('button >> text=Edit');

            await expect(page.locator('div.animalInfo >> h1', { hasText: `Name: ${petName}` })).toHaveCount(1);
        });

        test.skip('Delete a Postcard', async () => {
            await page.click('text=Dashboard');
            const detailsBtn = page.locator('div.animals-board', { hasText: petName })
                .locator('a >> text=Details');
            await detailsBtn.click();

            await page.click('a >> text=Delete');

            await expect(page).toHaveURL(host + '/catalog');
            await expect(page.locator('div.animals-board >> h2.name', { hasText: petName })).toHaveCount(0);
        });
    });
})