using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDemos.Tests
{
	public class ZoomTest : BaseTest
	{
		[OneTimeSetUp]
		public void NavigateToWebView()
		{
			_driver.FindElement(MobileBy.AccessibilityId("Views")).Click();

			var selector = "new UiSelector().text(\"WebView\")";
			ScrollToElement(selector);

			_driver.FindElement(MobileBy.AccessibilityId("WebView")).Click();

			var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
			var pageTitle = wait.Until(drv => drv.FindElement(MobileBy.AndroidUIAutomator("new UiSelector().text(\"This page is a Selenium sandbox\")")));
			Assert.That(pageTitle.Text, Is.EqualTo("This page is a Selenium sandbox"));
		}

		[Test, Order(1)]
		public void Test_ZoomIn()
		{
			PerformZoom(112, 655, 123, 370, 105, 785, 90, 1058);
		}

		[Test, Order(2)]
		public void Test_ZoomOut()
		{
			PerformZoom(123, 370, 112, 655, 90, 1058, 105, 785);
		}
	}
}
