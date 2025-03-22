using SaucedemoPOM.Pages;

namespace SaucedemoPOM.Tests
{
	[TestFixture]
	public class InventoryTests : BaseTest
	{
		private InventoryPage inventoryPage;

		[SetUp]
		public void InventorySetUp()
		{
			Login("standard_user", "secret_sauce");

			inventoryPage = new InventoryPage(_driver);
		}
		[Test]
		public void Test_InventoryDisplay()
		{
			Assert.That(inventoryPage.isInventoryDisplayed(), Is.True);
		}

		[Test]
		public void Test_AddToCartByIndex()
		{ 
			inventoryPage.AddToCartByIndex(0);
			inventoryPage.ClickCartLink();

			var cartPage = new CartPage(_driver);
			Assert.That(cartPage.isCartItemDisplayed(), Is.True);
		}

		[Test]
		public void Test_AddToCartByName()
		{
			inventoryPage.AddToCartByName("Sauce Labs Bike Light");
			inventoryPage.ClickCartLink();

			var cartPage = new CartPage(_driver);
			Assert.That(cartPage.isCartItemDisplayed(), Is.True);
		}

		[Test] 
		public void Test_PageTitle()
		{
			Assert.That(inventoryPage.isPageLoaded(), Is.True);
		}
	}
}
