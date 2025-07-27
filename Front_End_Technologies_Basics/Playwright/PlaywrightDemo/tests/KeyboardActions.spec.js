import { test } from '@playwright/test'

test('Ctrl+C and Ctrl+V', async ({ page }) => {
    await page.goto('https://gotranscript.com/text-compare');

    await page.locator('//textarea[@name="text1"]').fill('welcome to automation...');

    await page.keyboard.press('Control+A');
    await page.keyboard.press('Control+C');
    await page.keyboard.down('Tab');
    await page.keyboard.up('Tab');
    await page.keyboard.press('Control+V');
});