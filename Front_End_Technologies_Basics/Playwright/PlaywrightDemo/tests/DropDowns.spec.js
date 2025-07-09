import { test, expect } from '@playwright/test';

test('Dropdowns', async ({ page }) => {
    await page.goto('https://testautomationpractice.blogspot.com');

    await page.locator('#country').selectOption('Canada');
    await page.locator('#country').selectOption({ label: 'India' });
    await page.locator('#country').selectOption({ value: 'france' });
    await page.locator('#country').selectOption({ index: 2 }); // United Kingdom
    await page.selectOption('#country', { value: 'japan' });


    // Assertions
    const options = await page.locator('#country option');
    await expect.soft(options).toHaveCount(10);

    const optionsArr = await page.$$('#country option');
    await expect.soft(optionsArr).toHaveLength(10);
    expect.soft(optionsArr.length).toBe(10);

    const content = await page.locator('#country').textContent();
    expect.soft(content.includes('India')).toBeTruthy();
    expect.soft(content.includes('xyz')).toBeFalsy();

    for (const option of optionsArr) {
        let value = await option.textContent();

        if (value.includes('France')) {
            await page.selectOption('#country', 'France');
            break;
        }
    }

    //await page.waitForTimeout(3000);
});

test('Multi select dropdown', async ({ page }) => {
    await page.goto('https://testautomationpractice.blogspot.com');

    const optionsToSelect = ['White', 'Green', 'Red'];
    await page.selectOption('#colors', optionsToSelect);

    const options = page.locator('#colors option');

    await expect(options).toHaveCount(7);
});