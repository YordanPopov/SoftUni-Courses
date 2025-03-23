using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SaucedemoPOM.Pages;

namespace SaucedemoPOM.Tests
{
	[TestFixture]
	public class BaseTest
	{
		protected IWebDriver _driver;
		protected CheckoutPage checkoutPage;
		protected LoginPage loginPage;
		protected InventoryPage inventoryPage;
		protected CartPage cartPage;
		protected HiddenMenuPage menu;

		[SetUp]
		public void Setup()
		{
			var chromeOptions = new ChromeOptions();
			chromeOptions.AddUserProfilePreference("profile.password_manager_enabled", false);
			chromeOptions.AddArgument("--headless");

			string chromeDriverPath = @"D:\Programs\chromedriver-win64\chromedriver-win64\chromedriver.exe";
			_driver = new ChromeDriver(chromeDriverPath, chromeOptions);

			//_driver.Manage().Window.Maximize();
			_driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

			loginPage = new LoginPage(_driver);
			checkoutPage = new CheckoutPage(_driver);
			inventoryPage = new InventoryPage(_driver);
			cartPage = new CartPage(_driver);
			menu = new HiddenMenuPage(_driver);
		}

		[TearDown]
		public void Teardown()
		{
			if (_driver != null)
			{
				_driver.Quit();
				_driver.Dispose();
			}
		}

		protected void Login(string username, string password)
		{
			_driver.Navigate().GoToUrl("https://www.saucedemo.com/");
			loginPage = new LoginPage(_driver);

			loginPage.InputUsername(username);
			loginPage.InputPassword(password);
			loginPage.ClickLoginButton();
		}

		protected void EnterUserData(string firstName, string lastName, string postalCode)
		{
			checkoutPage.EnterFirstName(firstName);
			checkoutPage.EnterLastName(lastName);
			checkoutPage.EnterPostalCode(postalCode);
		}
	}
}
