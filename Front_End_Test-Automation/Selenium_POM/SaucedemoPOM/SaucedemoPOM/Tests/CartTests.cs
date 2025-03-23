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

			inventoryPage.AddToCartByName("Sauce Labs Bike Light");
			inventoryPage.ClickCartLink();
		}

		[Test]
		public void Test_CartItemDisplayed()
		{
			Assert.That(cartPage.isCartItemDisplayed(), Is.True);
		}

		[Test]
		public void Test_ClickCheckout()
		{
			cartPage.ClickCheckout();
			Assert.That(_driver.Url, Does.Contain("/checkout"));
			
		}
	}
}
