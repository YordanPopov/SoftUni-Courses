const { expect, test, chromium } = require('@playwright/test');

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

test.describe('e2e tests', () => {
    test.beforeAll(async () => {
        browser = await chromium.launch();
    });

    test.afterAll(async () => {
        await browser.close();
    });

    test.beforeEach(async () => {
        context = await browser.newContext();
        page = await context.newPage();
    });

    test.afterEach(async () => {
        await page.close();
        await context.close();
    });

    test.describe('Authentication', async () => {
        test('Register with valid data', async ({ page }) => {
            await page.goto(host);
            await page.click('a[href="/register"]');
            await page.waitForSelector('form#register');

            let rnd = Math.floor(Math.random() * 10001);
            user.email = `testUser${rnd}@email.com`;

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

        test('Register with different confirm password', async ({ page }) => {
            await page.goto(host);
            await page.locator('a[href="/register"]').click();
            await page.waitForSelector('form#register');

            await page.locator('input#email').fill(user.email);
            await page.locator('input#register-password').fill(user.pass);
            await page.locator('input#confirm-password').fill('654321');

            page.on('dialog', async dialog => {
                expect(dialog.type()).toContain('alert');
                expect(dialog.message()).toContain('password has to match password!');
                dialog.accept();
            });
            await page.locator('input.btn.submit').click();

            await page.waitForURL(host + '/register');
            expect(page.url()).toBe(host + '/register');
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

        test('Login with invalid password', async ({ page }) => {
            await page.goto(host);
            await page.locator('a >> text=Login').click();
            await page.waitForSelector('form#login');
            await page.fill('input[name="email"]', user.email);
            await page.fill('input[name="password"]', '654321');

            page.on('dialog', async dialog => {
                expect(dialog.type()).toContain('alert');
                expect(dialog.message()).toContain('Unable to log in!');
                dialog.accept();
            });
            await page.click('input.btn.submit');

            await page.waitForURL(host + '/login');
            expect(page.url()).toBe(host + '/login');
        });

        test('Login with non-existent user', async ({ page }) => {
            await page.goto(host);
            await page.locator('a >> text=Login').click();
            await page.waitForSelector('form#login');
            await page.fill('input[name="email"]', 'invalidUser@email.com');
            await page.fill('input[name="password"]', '123456');

            page.on('dialog', async dialog => {
                expect(dialog.type()).toContain('alert');
                expect(dialog.message()).toContain('Unable to log in!');
                dialog.accept();
            });
            await page.click('input.btn.submit');

            await page.waitForURL(host + '/login');
            expect(page.url()).toBe(host + '/login');
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
        });
    });

    test.describe('Navbar', () => {
        test.beforeEach('Open home page URL', async ({ page }) => {
            await page.goto(host);
        });

        test('Navigation bar for logged-in user', async ({ page }) => {
            await page.locator('a >> text=Login').click();
            await page.locator('input#email').fill('peter@abv.bg');
            await page.locator('input#login-password').fill('123456');
            await page.locator('input.btn.submit').click();

            await expect(page.locator('a.home >> text=GamesPlay')).toBeVisible();
            await expect(page.locator('a >> text=All games')).toBeVisible();
            await expect(page.locator('a >> text=Create game')).toBeVisible();
            await expect(page.locator('a >> text=Logout')).toBeVisible();
            await expect(page.locator('a >> text=Login')).toBeHidden();
            await expect(page.locator('a >> text=Register')).toBeHidden();
        });

        test('Navigation bar for gurst user', async ({ page }) => {
            await expect(page.locator('a.home >> text=GamesPlay')).toBeVisible();
            await expect(page.locator('a >> text=All games')).toBeVisible();
            await expect(page.locator('a >> text=Login')).toBeVisible();
            await expect(page.locator('a >> text=Register')).toBeVisible();
            await expect(page.locator('a >> text=Logout')).toBeHidden();
        });
    });

    test.describe('CRUD', () => {
        test.beforeEach('login', async ({ page }) => {
            page.goto(host + '/login');
            await page.locator('input#email').fill(user.email);
            await page.locator('input#login-password').fill(user.pass);
            await page.locator('input.btn.submit').click();
        });

        test('Create game with empty fields', async ({ page }) => {
            await page.click('a >> text=Create Game');
            await page.waitForSelector('form#create');

            page.on('dialog', async dialog => {
                expect(dialog.type()).toContain('alert');
                expect(dialog.message()).toContain('All fields are required!');
                await dialog.accept();
            });
            await page.locator('input.btn.submit').click();

            expect(page).toHaveURL(host + '/create');
        });

        test('Create game with valid values', async ({ page }) => {
            await page.click('a >> text=Create Game');
            await page.waitForSelector('form#create');

            let rnd = Math.floor(Math.random() * 101);
            game.title = `Test-Title${rnd}`;
            game.category = `Test-Category${rnd}`;

            await page.locator('input[name="title"]').fill(game.title);
            await page.locator('input[name="category"]').fill(game.category);
            await page.locator('input[name="maxLevel"]').fill(game.maxLevel);
            await page.locator('input[name="imageUrl"]').fill(game.imageUrl);
            await page.locator('textarea[name="summary"]').fill(game.summary);
            await page.locator('input.btn.submit').click();

            await page.waitForSelector('div.game');
            const lastCreatedGameTitle = await page.textContent('div.game >> h3');
            expect(lastCreatedGameTitle).toBe(game.title);
            expect(page.url()).toBe(host + '/');
        });

        test('[Edit] and [Delete] buttons are visible for creator', async ({ page }) => {
            await page.waitForSelector('div.game');
            await page.click('div.game >> div.data-buttons >> a >> text=Details');
            game.id = page.url().split('/').pop();
            await page.waitForSelector('div.info-section');

            await expect(page.locator('div.buttons >> a >> text=Edit')).toBeVisible();
            await expect(page.locator('div.buttons >> a >> text=Delete')).toBeVisible();
        });

        test('[Edit] and [Delete] buttons are not visible for non-creator', async ({ page }) => {
            await page.click('a >> text=All games');
            const detailsBtn = page.locator('.allGames-info', { hasText: 'Zombie Lang' }).locator('a.details-button');
            await detailsBtn.click();

            await expect(page.locator('div.buttons >> a >> text=Edit')).toBeHidden();
            await expect(page.locator('div.buttons >> a >> text=Delete')).toBeHidden();
        });

        test('Creator can edit the game', async ({ page }) => {
            await page.waitForSelector('div.game');
            await page.click('div.game >> div.data-buttons >> a >> text=Details');
            await page.waitForSelector('div.info-section');

            await page.click('div.buttons >> a >> text=Edit');
            await page.waitForSelector('form#edit');
            await page.locator('input#title').fill('Edited Title');
            await page.click('input.btn.submit');

            await page.waitForSelector('div.info-section');
            const editedTitle = await page.textContent('div.game-header h1');
            expect(editedTitle).toBe('Edited Title');
        });

        test('Creator can delete the game', async ({ page }) => {
            await page.waitForSelector('div.game');
            await page.click('div.game >> div.data-buttons >> a >> text=Details');
            await page.waitForSelector('div.info-section');

            await page.click('div.buttons >> a >> text=Delete');
            await page.waitForURL(host + '/');
            await expect(page.locator('div#home-page')).not.toContainText('Edited Title');
        });
    });

    test.describe('Home Page', async () => {
        test('Show home page for guest user', async ({ page }) => {
            await page.goto(host);

            await expect(page.locator('.welcome-message >> h2')).toHaveText('ALL new games are');
            await expect(page.locator('.welcome-message >> h3')).toHaveText('Only in GamesPlay');
            await expect(page.locator('#home-page h1')).toHaveText('Latest Games');

            const games = await page.locator('div.game').all();
            expect(games.length).toBeGreaterThanOrEqual(3);
        });
    });
});