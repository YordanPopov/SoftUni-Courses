import { test, expect } from '@playwright/test';

test('test1', async ({ page }) => {
    await page.goto('https://opensource-demo.orangehrmlive.com/web/index.php/auth/login');
    await expect(page).toHaveTitle('OrangeHRM');
});

test('test2', async ({ page }) => {
    await page.goto('https://www.orangehrm.com/');
    await expect(page).toHaveTitle('Human Resources Management Software | HRMS | OrangeHRM');
});

test('test3', async ({ page }) => {
    await page.goto('https://demoblaze.com/index.html');
    await expect(page).toHaveTitle('STORE');
});