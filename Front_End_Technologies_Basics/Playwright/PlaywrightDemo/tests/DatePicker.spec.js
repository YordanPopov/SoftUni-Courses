import { test } from '@playwright/test'

test('Date picker1', async ({ page }) => {
    await page.goto('https://testautomationpractice.blogspot.com/');

    await page.fill('#datepicker', '08/25/2025');

    const year = '2030';
    const month = 'December';
    const day = '25'

    while (true) {
        const currentYear = await page.locator('.ui-datepicker-year').textContent();
        const currentMonth = await page.locator('.ui-datepicker-month').textContent();

        if (currentYear === year && currentMonth === month) {
            break;
        }

        await page.locator('a[title="Next"]').click();
        await page.waitForTimeout(100);
    }

    const dates = await page.$$('td .ui-state-default');

    for (const date of dates) {
        if (await date.textContent() === day) {
            await date.click();
            break;
        }
    }
});

test('Date picker2', async ({ page }) => {
    await page.goto('https://testautomationpractice.blogspot.com/');

    await page.locator('#txtDate').click();
    await page.locator('.ui-datepicker-month').selectOption({ label: 'Dec' });
    await page.locator('.ui-datepicker-year').selectOption({ label: '2030' });
    await page.locator(`//a[@class="ui-state-default"][text()="25"]`).click();
});