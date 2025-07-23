import { expect, test } from '@playwright/test'

test('Mouse hover', async ({ page }) => {
    await page.goto('https://testautomationpractice.blogspot.com');

    const pointMe = await page.locator('.dropbtn');
    const mobiles = await page.locator('div.dropdown-content a:has-text("Mobiles")');
    const laptops = await page.locator('div.dropdown-content a:has-text("Laptops")');

    await pointMe.hover();
    await expect(mobiles).toBeVisible();
    await expect(laptops).toBeVisible();

    await mobiles.hover();
    await laptops.hover();
});

test('Double click', async ({ page }) => {
    await page.goto('https://testautomationpractice.blogspot.com');

    const firstField = await page.locator('#field1');
    const secondField = await page.locator('#field2');
    const copyBtn = await page.locator('button:has-text("Copy Text")');

    const firstFieldText = await firstField.inputValue();

    await copyBtn.dblclick();
    await expect(secondField).toHaveValue(firstFieldText);
});

test('Drag and Drop', async ({ page }) => {
    await page.goto('https://testautomationpractice.blogspot.com');

    const draggableElement = await page.locator('#draggable');
    const targetElement = await page.locator('#droppable');

    await draggableElement.dragTo(targetElement);

    await page.waitForTimeout(3000);
});