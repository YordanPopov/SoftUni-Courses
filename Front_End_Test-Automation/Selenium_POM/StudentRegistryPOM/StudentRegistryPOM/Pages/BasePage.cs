using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistryPOM.Pages
{
	public class BasePage
	{
		protected readonly IWebDriver _driver;

		public BasePage(IWebDriver driver)
		{
			_driver = driver;
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
		}

		public virtual string PageUrl { get; }

		public IWebElement LinkHomePage =>
			_driver.FindElement(By.LinkText("Home"));

		public IWebElement LinkViewStudentsPage =>
			_driver.FindElement(By.LinkText("View Students"));

		public IWebElement LinkAddStudentsPage =>
			_driver.FindElement(By.LinkText("Add Student"));

		public IWebElement PageHeading =>
			_driver.FindElement(By.TagName("h1"));

		public void Open()
		{
			_driver.Navigate().GoToUrl(PageUrl);
		}

		public bool IsOpen()
		{
			return _driver.Url == PageUrl;
		}

		public string GetPageTitle()
		{
			return _driver.Title;
		}

		public string GetPageHeadingText()
		{
			return PageHeading.Text;
		}
	}
}
