using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SaucedemoPOM.Pages;

namespace SaucedemoPOM.Tests
{
	[TestFixture]
	public class BaseTest
	{
		protected IWebDriver _driver;

		[SetUp]
		public void Setup()
		{
			var chromeOptions = new ChromeOptions();
			chromeOptions.AddUserProfilePreference("profile.password_manager_enabled", false);

			string chromeDriverPath = @"D:\Programs\chromedriver-win64\chromedriver-win64\chromedriver.exe";
			_driver = new ChromeDriver(chromeDriverPath, chromeOptions);

			_driver.Manage().Window.Maximize();
			_driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
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
			var loginPage = new LoginPage(_driver);

			loginPage.InputUsername(username);
			loginPage.InputPassword(password);
			loginPage.ClickLoginButton();
		}
	}
}
