using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeaCenterPOM.Pages
{
	public class BasePage
	{
		protected IWebDriver driver;

		public BasePage(IWebDriver driver)
		{
			this.driver = driver;
		}

		public virtual string PageUrl { get; set; } = "http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com:83";

		public void OpenPage()
		{
			driver.Navigate().GoToUrl(PageUrl);
		}
	}
}
