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

let albumName = "";

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
        test('Registration with valid data', async ({ page }) => {
            await page.goto(host);
            await page.click('text=Register');
            await page.waitForSelector('form');

            let rnd = Math.floor(Math.random() * 1001);
            user.email = `TestUser${rnd}@email.com`;

            await page.fill('#email', user.email);
            await page.fill('#password', user.password);
            await page.fill('#conf-pass', user.confirmPass);
            await page.click('[type="submit"]');

            await expect(page).toHaveURL(host + '/');
            await expect(page.locator('text=Logout')).toBeVisible();
        });

        test('Login with valid data', async ({ page }) => {
            await page.goto(host);
            await page.click('text=Login');
            await page.waitForSelector('form');
            await page.fill('#email', user.email);
            await page.fill('#password', user.password);
            await page.click('[type="submit"]');

            await expect(page).toHaveURL(host + '/');
            await expect(page.locator('text=Logout')).toBeVisible();
        });

        test('Logout from the Application', async ({ page }) => {
            await page.goto(host);
            await page.click('text=Login');
            await page.waitForSelector('form');
            await page.fill('#email', user.email);
            await page.fill('#password', user.password);
            await page.click('[type="submit"]');

            await page.click('text=Logout');

            await page.waitForSelector('text=Login');
            await expect(page).toHaveURL(host + '/');
        });
    });

    describe("navbar", () => {
        test('Navigation for Logged-in user', async ({ page }) => {
            await page.goto(host);
            await page.click('text=Login');
            await page.waitForSelector('form');
            await page.fill('#email', user.email);
            await page.fill('#password', user.password);
            await page.click('[type="submit"]');

            await expect(page.locator('text=Home')).toBeVisible();
            await expect(page.locator('text=Catalog')).toBeVisible();
            await expect(page.locator('text=Search')).toBeVisible();
            await expect(page.locator('text=Create Album')).toBeVisible();
            await expect(page.locator('text=Logout')).toBeVisible();
            await expect(page.locator('text=Login')).toBeHidden();
            await expect(page.locator('text=Register')).toBeHidden();
        });

        test('Navigation for guest user', async ({ page }) => {
            await page.goto(host);
            await expect(page.locator('text=Home')).toBeVisible();
            await expect(page.locator('text=Catalog')).toBeVisible();
            await expect(page.locator('text=Search')).toBeVisible();
            await expect(page.locator('text=Login')).toBeVisible();
            await expect(page.locator('text=Register')).toBeVisible();
            await expect(page.locator('text=Create Album')).toBeHidden();
            await expect(page.locator('text=Logout')).toBeHidden();
        });
    });

    describe("CRUD", () => {
        beforeEach(async ({ page }) => {
            await page.goto(host);
            await page.click('text=Login');
            await page.waitForSelector('form');
            await page.fill('#email', user.email);
            await page.fill('#password', user.password);
            await page.click('[type="submit"]');
        });

        test('Create an album with valid data', async ({ page }) => {
            await page.click('text=Create Album');
            await page.waitForSelector('form');

            let rnd = Math.floor(Math.random() * 10001);
            albumName = `Test-Album-${rnd}`;

            await page.fill('#name', albumName);
            await page.fill('#imgUrl', 'https://daily.jstor.org/wp-content/uploads/2023/01/good_times_with_bad_music_1050x700.jpg');
            await page.fill('#price', '20');
            await page.fill('#releaseDate', '20, Jan, 2020');
            await page.fill('#artist', 'SomeArtist');
            await page.fill('#genre', 'SomeGenre');
            await page.getByPlaceholder('Description').fill('SomeDescription');
            await page.click('button.add-album');

            await expect(page).toHaveURL(host + '/catalog');
            await expect(page.locator('div.text-center p.name', { hasText: albumName })).toHaveCount(1);
        });

        test('Edit an album', async ({ page }) => {
            await page.click('a >> text=Search');
            await page.fill('#search-input', albumName)
            await page.click('button >> text=Search');

            await page.locator('a >> text=Details').first().click();
            const albumId = page.url().split('/').pop();

            await page.locator('a >> text=Edit').click();
            await page.waitForSelector(`form[albumid="${albumId}"]`);

            albumName += '-Edited';
            await page.locator('#name').fill(albumName);
            await page.click('button.edit-album');

            await expect(page.locator('div.albumText >> h1', { hasText: `Name: ${albumName}` })).toHaveCount(1);
        });

        test('Delete an Album', async ({ page }) => {
            await page.click('text=Search');
            await page.fill('#search-input', albumName);
            await page.click('button >> text=Search');
            await page.locator('a >> text=Details').first().click();
            await page.click('a >> text=Delete');

            await expect(page).toHaveURL(host + '/catalog');
            await expect(page.locator('.text-center p.name', { hasText: albumName })).toHaveCount(0);
        });
    });
});