using IdeaCenterPOM.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeaCenterPOM.Tests
{
	[TestFixture]
	public class BaseTest
	{
		protected IWebDriver driver;
		protected WebDriverWait wait;
		protected Actions actions;
		protected LoginPage loginPage;
		protected CreateIdeaPage createIdeaPage;
		protected MyIdeasPage myIdeasPage;
		protected EditIdeaPage editIdeaPage;
		protected ViewIdeaPage viewIdeaPage;

		[OneTimeSetUp]
		public void OneTimeSetUp()
		{
			ChromeOptions options = new ChromeOptions();
			options.AddUserProfilePreference("profile.password_manager_enabled", false);
			options.AddArgument("--disable-search-engine-choice-screen");

			driver = new ChromeDriver(options);
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
			driver.Manage().Window.Maximize();
			wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
			actions = new Actions(driver);

			loginPage = new LoginPage(driver);
			createIdeaPage = new CreateIdeaPage(driver);
			myIdeasPage = new MyIdeasPage(driver);
			editIdeaPage = new EditIdeaPage(driver);
			viewIdeaPage = new ViewIdeaPage(driver);

			LoginUser("testUser_123@email.com", "test1234");
		}

		[OneTimeTearDown]
		public void OneTimeTearDown()
		{
			driver.Quit();
			driver.Dispose();
		}

		public void LoginUser(string email, string pass)
		{
			loginPage.OpenPage();

			loginPage.EmailField.Clear();
			loginPage.EmailField.SendKeys(email);

			loginPage.PassField.Clear();
			loginPage.PassField.SendKeys(pass);

			loginPage.SignInButton.Click();
		}

		public string GenerateRandomString(int length)
		{
			var rnd = new Random();
			const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
			return new string(Enumerable.Repeat(chars, length)
				.Select(s => s[rnd.Next(s.Length)]).ToArray());
		}
	}
}
