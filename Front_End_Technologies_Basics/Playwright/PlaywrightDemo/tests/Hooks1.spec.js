import { test, expect } from '@playwright/test'

test('Home page Test', async ({ page }) => {
    await page.goto('https://demoblaze.com/index.html');

    await page.locator('#login2').click();
    await page.locator('#loginusername').fill('jordan2');
    await page.locator('#loginpassword').fill('jordan1234');
    await page.locator("button[onclick='logIn()']").click();

    const products = await page.$$('h4.card-title a');

    expect(products).toHaveLength(9);

    await page.locator('#logout2').click();
});

test('Add product to cart Test', async ({ page }) => {
    await page.goto('https://demoblaze.com/index.html');

    await page.locator('#login2').click();
    await page.locator('#loginusername').fill('jordan2');
    await page.locator('#loginpassword').fill('jordan1234');
    await page.locator("button[onclick='logIn()']").click();

    await page.locator('h4.card-title a', { hasText: 'Samsung galaxy s6' }).click();

    page.on('dialog', async dialog => {
        expect(dialog.type()).toContain('alert');
        expect(dialog.message()).toContain('Product added');

        dialog.accept();
    });

    await page.locator('a[onclick="addToCart(1)"]').click();

    await page.locator('#logout2').click();
});