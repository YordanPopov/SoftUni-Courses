const { expect, test, chromium } = require('@playwright/test');

const host = 'http://localhost:3000/';

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
        // TO DO:
    });
});