using SaucedemoPOM.Pages;

namespace SaucedemoPOM.Tests
{
	[TestFixture]
	public class CartTests : BaseTest
	{
		[SetUp]
		public void CartSetUp()
		{
			Login("standard_user", "secret_sauce");

			var inventoryPage = new InventoryPage(_driver);
			inventoryPage.AddToCartByName("Sauce Labs Bike Light");
			inventoryPage.ClickCartLink();
		}

		[Test]
		public void Test_CartItemDisplayed()
		{
			var cartPage = new CartPage(_driver);
			Assert.That(cartPage.isCartItemDisplayed(), Is.True);
		}

		[Test]
		public void Test_ClickCheckout()
		{
			var cartPage = new CartPage(_driver);
			cartPage.ClickCheckout();
			Assert.That(_driver.Url, Does.Contain("/checkout"));
			
		}
	}
}
