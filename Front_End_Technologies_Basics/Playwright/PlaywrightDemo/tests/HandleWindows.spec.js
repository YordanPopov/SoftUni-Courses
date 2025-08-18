import { test, chromium, expect } from '@playwright/test';

let browser, context, pageOne, pageTwo;

test('Handle pages/windows', async () => {
    browser = await chromium.launch();
    context = await browser.newContext();
    pageOne = await context.newPage();
    pageTwo = await context.newPage();

    const allPages = context.pages();
    console.log(allPages.length);

    await pageOne.goto('https://opensource-demo.orangehrmlive.com/web/index.php/auth/login');
    await expect(pageOne).toHaveTitle('OrangeHRM');

    await pageTwo.goto('https://www.orangehrm.com/');
    await expect(pageTwo).toHaveTitle('Human Resources Management Software | HRMS | OrangeHRM');
});

test('Handle multiple pages/windows', async () => {
    browser = await chromium.launch();
    context = await browser.newContext();
    pageOne = await context.newPage();

    await pageOne.goto('https://opensource-demo.orangehrmlive.com/web/index.php/auth/login');
    await expect(pageOne).toHaveTitle('OrangeHRM');

    const pagePromise = context.waitForEvent('page');
    await pageOne.click('a[href="http://www.orangehrm.com"]');
    const newPage = await pagePromise;
    await expect(newPage).toHaveTitle('Human Resources Management Software | HRMS | OrangeHRM')
});