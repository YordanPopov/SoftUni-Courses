import { test, expect } from '@playwright/test'

test('Select single option', async ({ page }) => {
    await page.goto('https://testautomationpractice.blogspot.com');

    const table = await page.locator('#productTable');
    const tableColumns = await table.locator('thead tr th');
    const tableRows = await table.locator('tbody tr');

    expect(await tableColumns.count()).toBe(4);
    expect(await tableRows.count()).toBe(5);

    const matchedRow = tableRows.filter({
        has: page.locator('td'),
        hasText: 'Tablet'
    });

    await matchedRow.locator('input').check();

    await page.waitForTimeout(3000);
});

test('Select multiple options', async ({ page }) => {
    await page.goto('https://testautomationpractice.blogspot.com');

    const table = await page.locator('#productTable');
    const rows = await table.locator('tbody tr');
    const columns = await table.locator('thead th');
    const pagination = await page.locator('.pagination li');

    for (let p = 1; p <= await pagination.count(); p++) {
        if (p > 1) {
            await page.locator(`.pagination li:nth-child(${p}) a`)
                .click();
        }
        for (let r = 1; r <= await rows.count(); r++) {
            const currentCheckbox = await table.locator(`tbody tr:nth-child(${r}) td:nth-child(${await columns.count()}) input`);
            await currentCheckbox.check();

            expect(await currentCheckbox.isChecked()).toBeTruthy();
        }
    }
});