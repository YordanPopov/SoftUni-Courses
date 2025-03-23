using SaucedemoPOM.Pages;

namespace SaucedemoPOM.Tests
{
	[TestFixture]
	public class HiddenMenuTests : BaseTest
	{
		[SetUp]
		public void menuSetUp()
		{
			Login("standard_user", "secret_sauce");
		}

		[Test]
		public void Test_OpenMenu()
		{
			menu.ClickMenuButton();
			Assert.That(menu.IsMenuOpened(), Is.True);
		}

		[Test]
		public void Test_LogoutButton()
		{
			menu.ClickMenuButton();
			Assert.That(menu.IsMenuOpened(), Is.True);

			menu.ClickLogoutButton();
			Assert.That(_driver.Url, Is.EqualTo("https://www.saucedemo.com/"));
		}
	}
}
