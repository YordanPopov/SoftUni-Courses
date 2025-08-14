import { test } from '@playwright/test'

let page;

test.beforeAll(async ({ browser }) => {
    page = await browser.newPage();

    await page.goto('https://demoblaze.com/index.html');
});

test('Page screenshot test', async () => {
    await page.screenshot({ path: 'tests\\Screenshots\\' + Date.now() + '_HomePage.png' });
});

test('Full page screenshot test', async () => {
    await page.screenshot({ path: 'tests\\Screenshots\\' + Date.now() + '_FullPage.png', fullPage: true });
});
