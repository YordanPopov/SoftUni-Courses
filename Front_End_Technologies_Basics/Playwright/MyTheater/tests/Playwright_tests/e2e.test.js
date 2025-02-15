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

let event = {
    title: "",
    date: "June 14th 2000",
    author: "testAuthor",
    description: "This is a test description",
    imageUrl: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRe7sRR2BTeLfirdS33BUay46ef5kNOwwZYdg&s",
    id: ""
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
            await page.click('a >> text=Register');
            await page.waitForSelector('.registerForm');

            let random = Math.floor(Math.random() * 1001);
            user.email = `testUser${random}@email.com`;

            await page.getByPlaceholder('steven@abv.bg').fill(user.email);
            await page.locator('#password').fill(user.password);
            await page.locator('#repeatPassword').fill(user.confirmPass);

            let [response] = await Promise.all([
                page.waitForResponse(res => res.url().includes('/users/register') && res.status() === 200),
                page.click('button[type="submit"]')
            ]);

            expect(response.ok()).toBeTruthy();
            const userData = await response.json();
            expect(userData.email).toEqual(user.email);
            expect(userData.password).toEqual(user.password);

            await expect(page).toHaveURL(host + '/');
            await expect(page.locator('a >> text=Logout')).toBeVisible();
        });

        test('Login with valid data', async () => {
            await page.goto(host);
            await page.click('a >> text=Login');
            await page.waitForSelector('.loginForm');

            await page.getByPlaceholder('steven@abv.bg').fill(user.email);
            await page.locator('#password').fill(user.password);

            let [response] = await Promise.all([
                page.waitForResponse(res => res.url().includes('/users/login') && res.status() === 200),
                page.click('button >> text=Login')
            ]);

            expect(response.ok()).toBeTruthy();
            const userData = await response.json();
            expect(userData.email).toEqual(user.email);
            expect(userData.password).toEqual(user.password);

            await expect(page).toHaveURL(host + '/');
            await expect(page.locator('a >> text=Profile')).toBeVisible();
            await expect(page.locator('a >> text=Logout')).toBeVisible();
        });

        test('Logout from the application', async () => {
            await page.goto(host);
            await page.click('a >> text=Login');
            await page.waitForSelector('.loginForm');
            await page.getByPlaceholder('steven@abv.bg').fill(user.email);
            await page.locator('#password').fill(user.password);
            await page.click('button >> text=Login');

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
        test('Navigation for logged-in user', async () => {
            await page.goto(host);
            await page.click('a >> text=Login');
            await page.waitForSelector('.loginForm');
            await page.getByPlaceholder('steven@abv.bg').fill(user.email);
            await page.locator('#password').fill(user.password);
            await page.click('button >> text=Login');

            await expect(page.locator('a >> text=Theater')).toBeVisible();
            await expect(page.locator('a >> text=Profile')).toBeVisible();
            await expect(page.locator('a >> text=Create Event')).toBeVisible();
            await expect(page.locator('a >> text=Logout')).toBeVisible();
            await expect(page.locator('a >> text=Login')).toBeHidden();
            await expect(page.locator('a >> text=Register')).toBeHidden();
        });

        test('Navigation for guest user', async () => {
            await page.goto(host);

            await expect(page.locator('a >> text=Theater')).toBeVisible();
            await expect(page.locator('a >> text=Profile')).toBeHidden();
            await expect(page.locator('a >> text=Create Event')).toBeHidden();
            await expect(page.locator('a >> text=Logout')).toBeHidden();
            await expect(page.locator('a >> text=Login')).toBeVisible();
            await expect(page.locator('a >> text=Register')).toBeVisible();
        });
    });

    describe("CRUD", () => {
        beforeEach(async () => {
            await page.goto(host);
            await page.click('a >> text=Login');
            await page.waitForSelector('.loginForm');
            await page.getByPlaceholder('steven@abv.bg').fill(user.email);
            await page.locator('#password').fill(user.password);
            await page.click('button >> text=Login');
        });

        test('Create an event with valid data', async () => {
            await page.click('a >> text=Create Event');
            await page.waitForSelector('.create-form');

            let random = Math.floor(Math.random() * 1001);
            event.title = `testEvent${random}`;

            await page.locator('#title').fill(event.title);
            await page.locator('#date').fill(event.date);
            await page.locator('#author').fill(event.author);
            await page.locator('#description').fill(event.description);
            await page.locator('#imageUrl').fill(event.imageUrl);

            let [response] = await Promise.all([
                page.waitForResponse(res => res.url().includes('/data/theaters') && res.status() === 200),
                page.click('button[type="submit"]')
            ]);

            expect(response.ok()).toBeTruthy();
            const eventData = await response.json();
            expect(eventData.title).toEqual(event.title);
            expect(eventData.date).toEqual(event.date);
            expect(eventData.author).toEqual(event.author);
            expect(eventData.description).toEqual(event.description);
            expect(eventData.imageUrl).toEqual(event.imageUrl);

            await expect(page).toHaveURL(host + '/');
            await expect(page.locator('.eventsInfo .info h4', { hasText: event.title })).toHaveCount(1);
        });

        test('Edit an event with valid data', async () => {
            await page.click('a >> text=Profile');
            await page.locator('.event-info >> .details-button').first().click();
            await page.click('a.btn-edit');
            await page.waitForSelector('.theater-form');

            event.title += '-edited';
            event.id = page.url().split('/').pop();
            await page.locator('#title').fill(event.title);

            let [response] = await Promise.all([
                page.waitForResponse(res => res.url().includes('/data/theaters') && res.status() === 200),
                page.click('button[type="submit"]')
            ]);

            expect(response.ok()).toBeTruthy();
            const eventData = await response.json();
            expect(eventData.title).toEqual(event.title);
            expect(eventData.date).toEqual(event.date);
            expect(eventData.author).toEqual(event.author);
            expect(eventData.description).toEqual(event.description);
            expect(eventData.imageUrl).toEqual(event.imageUrl);

            await expect(page).toHaveURL(host + `/details/${event.id}`);
            await expect(page.locator('.detailsInfo h1', { hasText: event.title })).toBeVisible();
        });

        test('Delete an event', async () => {
            await page.click('a >> text=Profile');
            await page.locator('.event-info >> .details-button').first().click();

            let [response] = await Promise.all([
                page.waitForResponse(res => res.url().includes('/data/theaters') && res.status() === 200),
                page.on('dialog', async dialog => {
                    dialog.accept();
                }),
                page.click('a.btn-delete')
            ]);

            expect(response.ok()).toBeTruthy();
            await expect(page).toHaveURL(host + '/profile');
            await expect(page.locator('.no-events p', { hasText: 'This user has no events yet!' })).toBeVisible();
        });
    });
})