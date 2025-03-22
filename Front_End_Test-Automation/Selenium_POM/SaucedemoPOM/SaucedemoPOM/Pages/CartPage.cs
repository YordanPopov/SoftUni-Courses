using OpenQA.Selenium;

namespace SaucedemoPOM.Pages
{
	public class CartPage : BasePage
	{
		public CartPage(IWebDriver driver) : base(driver)
		{
		}

		private readonly By cartItem = By.ClassName("cart_item");
		private readonly By checkoutButton = By.Id("checkout");

		public bool isCartItemDisplayed()
		{
			return FindElement(cartItem).Displayed;
		}

		public void ClickCheckout()
		{
			Click(checkoutButton);
		}
	}
}
