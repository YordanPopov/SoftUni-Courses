import { expect, test } from '@playwright/test';

test('Alert', async ({ page }) => {
    await page.goto('https://testautomationpractice.blogspot.com');

    page.on('dialog', async dialog => {
        expect(dialog.type()).toContain('alert');
        expect(dialog.message()).toContain('I am an alert box!');

        await dialog.accept();
    });

    await page.locator('#alertBtn').click();

    await page.waitForTimeout(3000);
});

test('Confirm ok', async ({ page }) => {
    await page.goto('https://testautomationpractice.blogspot.com');

    page.on('dialog', async dialog => {
        expect(dialog.type()).toContain('confirm');
        expect(dialog.message()).toContain('Press a button!');

        await dialog.accept();
    });

    await page.locator('#confirmBtn').click();

    const msg = await page.locator('#demo').textContent();
    expect(msg).toBe('You pressed OK!');
});

test('Confirm cancel', async ({ page }) => {
    await page.goto('https://testautomationpractice.blogspot.com');

    page.on('dialog', async dialog => {
        expect(dialog.type()).toContain('confirm');
        expect(dialog.message()).toContain('Press a button!');

        await dialog.dismiss();
    });

    await page.locator('#confirmBtn').click();

    const msg = await page.locator('#demo').textContent();
    expect(msg).toBe('You pressed Cancel!');
});

test('Prompt', async ({ page }) => {
    await page.goto('https://testautomationpractice.blogspot.com');
    const name = 'John';

    page.on('dialog', async dialog => {
        expect(dialog.type()).toContain('prompt');
        expect(dialog.message()).toContain('Please enter your name:');
        expect(dialog.defaultValue()).toContain('Harry Potter');

        await dialog.accept(name);
    });

    await page.locator('#promptBtn').click();

    const msg = await page.locator('#demo').textContent();

    expect(msg).toBe(`Hello ${name}! How are you today?`);
});