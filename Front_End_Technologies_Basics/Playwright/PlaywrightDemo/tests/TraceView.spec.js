import { test, expect } from '@playwright/test'
import { chromium } from 'playwright-extra';

let page;
let context;
let browser;

const userName = 'jordan2';
const pass = 'jordan1234';

test.describe('Trace View demo', () => {

    test.beforeAll(async () => {
        browser = await chromium.launch({ headless: false });

        context = await browser.newContext();

        page = await browser.newPage();

        await page.goto('https://demoblaze.com/index.html');
    });

    test.afterAll(async () => {
        await browser.close();
    });

    test('Login with existing user', async () => {
        await page.locator('#login2').click();

        await page.locator('#loginusername').fill(userName);
        await page.locator('#loginpassword').fill(pass);
        await page.locator('button[onclick="logIn()"]').click();

        const expectedMsg = `Welcome ${userName}`
        await expect(page.locator('#nameofuser')).toHaveText(expectedMsg);

        await page.locator('#logout2').click();
    });

    test('Trace view demo on failure', async () => {
        await page.locator('#login2').click();

        await page.locator('#loginusername').fill(userName);
        await page.locator('#loginpassword').fill(pass);
        await page.locator('button[onclick="logIn()"]').click();

        await expect(page.locator('#nameofuser')).toHaveText('TEST');
    });
});