//import { expect, test } from "playwright/test";
const { test, expect } = require('@playwright/test');

test('Home Page', async ({ page }) => {
    await page.goto('https://demoblaze.com/index.html');

    //const pageTitle = await page.title();
    //const pageUrl = page.url();

    // Check if the page title is correct
    await expect(page).toHaveTitle('STORE');

    // Check if the page URL is correct
    await expect(page).toHaveURL('https://demoblaze.com/index.html');
});