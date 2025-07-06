import { test, expect } from '@playwright/test';

test('Handle Checkboxes', async ({ page }) => {

    await page.goto('https://testautomationpractice.blogspot.com/');

    // Single checkbox
    const mondayCheckbox = page.locator('//input[@id="monday" and @type="checkbox"]');

    expect.soft(await mondayCheckbox.isChecked()).toBeFalsy();

    await mondayCheckbox.check();
    expect.soft(await mondayCheckbox.isChecked()).toBeTruthy();

    // Check All Weekdays
    const weekDaysLocators = [
        '//input[@id="monday" and @type="checkbox"]',
        '//input[@id="tuesday" and @type="checkbox"]',
        '//input[@id="wednesday" and @type="checkbox"]',
        '//input[@id="thursday" and @type="checkbox"]',
        '//input[@id="friday" and @type="checkbox"]'
    ]

    for (const locator of weekDaysLocators) {
        const checkbox = page.locator(locator);
        if (!await checkbox.isChecked()) {
            await checkbox.check();
        }
    }

    for (const locator of weekDaysLocators) {
        const isChecked = await page.locator(locator).isChecked();
        expect.soft(isChecked).toBeTruthy();
    }

    // Uncheck All Weekdays
    for (const locator of weekDaysLocators) {
        const checkbox = page.locator(locator);
        if (await checkbox.isChecked()) {
            await checkbox.uncheck();
        }
    }
});