import { test, expect } from '@playwright/test';
import { LoginPage } from '../DemoBlazePages/LoginPage.js';
import { HomePage } from '../DemoBlazePages/HomePage.js';
import { CartPage } from '../DemoBlazePages/CartPage.js';

test('Add product to cart.', async ({ page }) => {
    const loginPage = new LoginPage(page);
    const homePage = new HomePage(page);
    const cartPage = new CartPage(page);

    await loginPage.GotoLoginPage();
    await loginPage.Login('jordan2', 'jordan1234');

    await expect(page.locator(homePage.welcomeLink)).toHaveText('Welcome jordan2');

    await homePage.AddProductToCart('Nexus 6');
    await homePage.OpenCart();

    const isProductAdded = await cartPage.CheckProductInCart('Nexus 6');
    expect(isProductAdded).toBe(true);
});