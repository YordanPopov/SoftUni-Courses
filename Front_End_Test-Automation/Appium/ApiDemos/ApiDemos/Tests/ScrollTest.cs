using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

namespace ApiDemos.Tests
{
	public class ScrollTest : BaseTest
	{
		[Test]
		public void Test_Scroll()
		{
			_driver.FindElement(MobileBy.AccessibilityId("Views"))
				.Click();

			string selector = "new UiSelector().text(\"Lists\")";
			ScrollToElement(selector);

			var lists = _driver.FindElement(MobileBy.AccessibilityId("Lists"));
			Assert.That(lists, Is.Not.Null);

			lists.Click();

			var listElements = _driver.FindElements(MobileBy.AndroidUIAutomator("new UiSelector()"));
			Assert.That(listElements, Is.Not.Null); 
		}

		private IWebElement ScrollToElement(string selector)
		{
			return _driver.FindElement(MobileBy.AndroidUIAutomator($"new UiScrollable(new UiSelector().scrollable(true)).scrollIntoView({selector})"));
		}
	}
}
