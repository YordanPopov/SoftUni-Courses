import { test, expect } from '@playwright/test';

test('Handle Input Box', async ({ page }) => {

    await page.goto('https://testautomationpractice.blogspot.com/');

    const nameInput = page.locator('#name');
    const emailInput = page.locator('//input[@id="email"]');
    const phoneInput = page.getByPlaceholder('Enter Phone');

    await expect.soft(nameInput).toHaveAttribute('type', 'text');
    await expect.soft(emailInput).toHaveAttribute('type', 'text');
    await expect.soft(phoneInput).toHaveAttribute('type', 'text');

    await nameInput.fill('John Doe');

    await expect(nameInput).toHaveValue('John Doe');
});