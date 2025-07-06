import { test, expect } from '@playwright/test';

test('Assertions', async ({ page }) => {

    await page.goto('https://demo.nopcommerce.com/register');

    // Page has URL
    expect(page).toHaveURL('https://demo.nopcommerce.com/register');

    // Page has title
    await expect(page).toHaveTitle('nopCommerce demo store. Register');

    // Element is visible
    const logoElement = await page.getByAltText('nopCommerce demo store');
    await expect(logoElement).toBeVisible();

    // Element is hidden
    //await expect(page.locator('')).toBeHidden();

    // Element is enabled
    const searchBox = await page.locator('#small-searchterms');
    await expect(searchBox).toBeEnabled();

    // Element is disabled
    //await expect(page.locator('')).toBeDisabled();

    // Radio/Checkbox is checked
     const maleRadioButton = await page.locator('#gender-male');
     maleRadioButton.click();

     await expect(maleRadioButton).toBeChecked();

     const newsLetterCheckbox = await page.locator('#Newsletter');
     await expect(newsLetterCheckbox).toBeChecked();

     // Element has attribute
     const registerButton = await page.locator('#register-button');
     await expect(registerButton).toHaveAttribute('type', 'submit');

    // Element matches text
    const pageTitle = await page.locator('//div[@class="page-title"]/h1');
    await expect(pageTitle).toHaveText('Register');

    // Element contains text
    await expect(pageTitle).toContainText('Reg');
    
    // Input has value
    const emailInput = await page.locator('#Email');
    emailInput.fill('test@test.com');
    await expect(emailInput).toHaveValue('test@test.com');
    
    // List of elements has given length
    const titles = await page.locator('//div[@class="title"]/strong');
    await expect(titles).toHaveCount(9);

    // soft assertions
    await expect.soft(page).toHaveURL('https://demoblaze.com/index.html');
});