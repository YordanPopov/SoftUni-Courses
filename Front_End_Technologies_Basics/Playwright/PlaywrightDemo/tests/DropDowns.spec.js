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

test('Hidden options dropdown', async ({ page }) => {
    await page.goto('https://opensource-demo.orangehrmlive.com/web/index.php/auth/login');

    await page.getByPlaceholder('Username').fill('Admin');
    await page.getByPlaceholder('Password').fill('admin123');
    await page.getByRole('button', { type: 'submit' }).click();

    await page.locator('//div[@class="oxd-sidepanel-body"]//ul/li/a/span[text()="PIM"]').click();

    await page.locator('//div[@class="oxd-select-wrapper"]//div[@class="oxd-select-text--after"]/i').nth(2).click();

    await page.waitForTimeout(3000);
    const options = await page.$$('//div[@role="listbox"]//span');

    for (const option of options) {
        const jobTitle = await option.textContent();

        if (jobTitle.includes('QA Engineer')) {
            await option.click();
        }
    }

    //await page.waitForTimeout(3000);
});

test.only('Auto suggest dropdown', async ({ page }) => {
    await page.goto('https://www.redbus.in');

    await page.click('//i[@class="icon___ceddca icon icon-boarding_point"]');
    await page.click(`//div[contains(text(),'Mumbai')]`);

    await page.click(`//div[contains(text(),'Aurangabad (Maharashtra)')]`)

    await page.click(`//button[normalize-space()='Search buses']`);

    await page.waitForTimeout(3000);
    
    const pageUrl = await page.url();
    expect(pageUrl).toContain('/bus-tickets/');
});