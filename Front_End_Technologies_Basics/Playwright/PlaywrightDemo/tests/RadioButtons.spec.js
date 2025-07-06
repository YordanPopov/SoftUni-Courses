import { test, expect } from '@playwright/test';

test('Handle Radio Buttons', async ({ page }) => {

    await page.goto('https://testautomationpractice.blogspot.com/');

    const maleButton = page.locator('#male');
    const femaleButton = page.locator('#female');

    await expect.soft(maleButton).toHaveAttribute('type', 'radio');
    await expect.soft(maleButton).not.toBeChecked();

    await maleButton.check();
    expect.soft(maleButton.isChecked()).toBeTruthy();

    await expect.soft(femaleButton).toHaveAttribute('type', 'radio');
    await expect.soft(femaleButton).not.toBeChecked();
});