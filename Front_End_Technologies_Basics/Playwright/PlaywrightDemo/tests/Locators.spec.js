import { test, expect } from '@playwright/test';
// Locate single element
// await page.locator('locator').click();
// await page.click('locator');
// await page.locator('locator').fill('text');

test('Locate single element', async ({ page }) => {

    await page.goto('https://demoblaze.com/index.html');
    const userName = 'testUser';
    const password = 'testPassword';

    await page.locator('#login2').click();
    //await page.click('#login2');

    await page.locator('#loginusername').fill(userName);
    await page.locator('#loginpassword').fill(password);
    await page.locator('button[onclick="logIn()"]').click();

    const logoutLink = page.locator('#logout2');
    const userLink = page.locator('#nameofuser');

    await expect(logoutLink).toBeVisible();
    await expect(userLink).toBeVisible();
    await expect(userLink).toHaveText(`Welcome ${userName}`);
});

// Locate multiple elements
// const elements = await page.$$('locator');

test('Locate multiple elements', async ({ page }) => {

    await page.goto('https://demoblaze.com/index.html');

    await page.waitForSelector('//div[@id="tbodyid"]//h4');
    const products = await page.$$('//div[@id="tbodyid"]//h4');

    for (const product of products) {
        const productName = await product.textContent();
        console.log(productName);
    }
});

// Built-in locators
// await page.getAltText()
// await page.getByPlaceholder()
// await page.getByRole()
// await page.getByText()
// await page.getByTitle()
// await page.getByTestId()
// await page.getByLabel()

test('Built-in locators', async ({ page }) => {
    await page.goto('https://opensource-demo.orangehrmlive.com/web/index.php/auth/login');

    const logo = page.getByAltText('company-branding');
    await expect(logo).toBeVisible();

    await page.getByPlaceholder('Username').fill('Admin');
    await page.getByPlaceholder('Password').fill('admin123');
    await page.getByRole('button', { type: 'submit' }).click();

    await expect(page.getByText('My Actions')).toBeVisible();
});
