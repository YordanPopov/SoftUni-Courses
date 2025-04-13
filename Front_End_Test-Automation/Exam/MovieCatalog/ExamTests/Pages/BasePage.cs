using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamTests.Pages
{
	public class BasePage
	{
		protected IWebDriver _driver;

		protected WebDriverWait _wait;

		protected Actions actions;

		public BasePage(IWebDriver driver)
		{
			_driver = driver;
			_wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
			actions = new Actions(driver);
		}

		public virtual string PageUrl { get; set; } = "https://d24hkho2ozf732.cloudfront.net";

		public void OpenPage()
		{
			_driver.Navigate().GoToUrl(PageUrl);
		}

		public bool IsPageOpened()
		{
			return _wait.Until(ExpectedConditions.UrlToBe(PageUrl));
		}
	}
}
