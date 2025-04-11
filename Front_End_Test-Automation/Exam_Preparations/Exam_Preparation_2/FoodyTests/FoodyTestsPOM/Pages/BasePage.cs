using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodyTestsPOM.Pages
{
	public class BasePage
	{
		protected IWebDriver driver;

		protected WebDriverWait wait;

		public BasePage(IWebDriver drv)
		{
			this.driver = drv;
			wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
		}

		public virtual string PageUrl { get; set; } = "http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com:85";

		public void OpenPage()
		{
			driver.Navigate().GoToUrl(PageUrl);
		}

		public bool IsPageOpened()
		{
			return wait.Until(ExpectedConditions.UrlToBe(PageUrl));
		}
	}
}
