using ExamTests.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamTests.Tests
{
	public class BaseTest
	{
		public IWebDriver _driver;

		public Actions actions;

		public HomePage _homePage;

		public LoginPage _loginPage;

		public AddMoviePage _addMoviePage;

		public AllMoviesPage _allMoviesPage;

		public EditMoviePage _editMoviePage;

		public WatchedMoviesPage _watchedMoviesPage;

		public DeleteMoviePage _deleteMoviePage;

		[OneTimeSetUp]
		public void OneTimeSetUp()
		{
			ChromeOptions options = new ChromeOptions();
			options.AddUserProfilePreference("profile.password_manager_enabled", false);
			options.AddArgument("--disable-search-engine-choice-screen");

			_driver = new ChromeDriver(options);
			_driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
			_driver.Manage().Window.Maximize();

			actions = new Actions(_driver);
			_homePage = new HomePage(_driver);
			_loginPage = new LoginPage(_driver);
			_addMoviePage = new AddMoviePage(_driver);
			_allMoviesPage = new AllMoviesPage(_driver);
			_editMoviePage = new EditMoviePage(_driver);
			_watchedMoviesPage = new WatchedMoviesPage(_driver);
			_deleteMoviePage = new DeleteMoviePage(_driver);

			_loginPage.OpenPage();
			_loginPage.LoginUser("", "");
		}

		[OneTimeTearDown]
		public void OneTimeTearDown()
		{
			_driver.Quit();
			_driver.Dispose();
		}

		public string GenerateRandomString(int length)
		{
			var rnd = new Random();
			const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
			return new string(Enumerable.Repeat(chars, length)
				.Select(s => s[rnd.Next(s.Length)]).ToArray());
		}
	}
}
