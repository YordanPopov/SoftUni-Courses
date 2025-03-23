using SaucedemoPOM.Pages;

namespace SaucedemoPOM.Tests
{
	[TestFixture]
	public class CheckoutTests : BaseTest
	{
		[SetUp]
		public void CheckoutSetUp()
		{
			Login("standard_user", "secret_sauce");

			inventoryPage.AddToCartByName("Sauce Labs Backpack");
			inventoryPage.ClickCartLink();
			cartPage.ClickCheckout();
		}
		[Test]
		public void Test_CheckoutPageLoaded()
		{
			Assert.That(checkoutPage.IsPageLoaded(), Is.True);
		}

		[Test]
		public void Test_ContinueToNextStep()
		{
			EnterUserData("testFirstName", "testLastName", "0000");
			checkoutPage.ClickContinue();

			Assert.That(_driver.Url, Does.Contain("step-two.html"));
		}

		[Test]
		public void Test_CompleteOrder()
		{
			EnterUserData("testFirstName", "testLastName", "0000");
			checkoutPage.ClickContinue();
			checkoutPage.ClickFinish();

			Assert.That(new CheckoutPage(_driver).IsCheckoutComplete(), Is.True);
		}
	}
}
