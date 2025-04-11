using FoodyTestsPOM.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodyTestsPOM.Tests
{
	public class BaseTest
	{
		public IWebDriver driver;

		public LoginPage loginPage;

		public AddFoodPage addFoodPage;

		public HomePage homePage;

		public EditFoodPage editFoodPage;

		public Actions actions;

		[OneTimeSetUp]
		public void OneTimeSetUp()
		{
			ChromeOptions options = new ChromeOptions();
			options.AddUserProfilePreference("profile.password_manager_enabled", false);
			options.AddArgument("--disable-search-engine-choice-screen");

			driver = new ChromeDriver(options);
			driver.Manage().Window.Maximize();
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);

			loginPage = new LoginPage(driver);
			addFoodPage = new AddFoodPage(driver);
			homePage = new HomePage(driver);
			editFoodPage = new EditFoodPage(driver);

			loginPage.OpenPage();
			loginPage.PerformLogin("testUser_123", "test1234");
			actions = new Actions(driver);
		}

		[OneTimeTearDown]
		public void OneTimeTearDown()
		{
			driver.Quit();
			driver.Dispose();
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
