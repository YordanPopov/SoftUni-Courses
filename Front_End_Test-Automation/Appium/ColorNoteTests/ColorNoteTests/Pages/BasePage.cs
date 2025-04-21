using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorNoteTests.Pages
{
	public class BasePage
	{
		protected AndroidDriver _driver;

		protected WebDriverWait _wait;

		protected Actions _actions;

		public BasePage(AndroidDriver driver)
		{
			_driver = driver;
			_wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
			_actions = new Actions(driver);
		}
	}
}
