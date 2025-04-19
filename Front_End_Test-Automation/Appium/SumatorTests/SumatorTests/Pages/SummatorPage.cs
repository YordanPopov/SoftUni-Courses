using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace SumatorTests.Pages
{
	public class SummatorPage
	{
		protected AndroidDriver _driver;

		protected WebDriverWait _wait;

		protected Actions actions;

		public SummatorPage(AndroidDriver driver)
		{
			_driver = driver;
			_wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
			actions = new Actions(driver);
		}

		public AppiumElement firstNumInput => _driver.FindElement(MobileBy.AndroidUIAutomator("new UiSelector().resourceId(\"com.example.androidappsummator:id/editText1\")"));

		public AppiumElement secondNumInput => _driver.FindElement(MobileBy.AndroidUIAutomator("new UiSelector().resourceId(\"com.example.androidappsummator:id/editText2\")"));

		public AppiumElement resultField => _driver.FindElement(MobileBy.AndroidUIAutomator("new UiSelector().resourceId(\"com.example.androidappsummator:id/editTextSum\")"));

		public AppiumElement calcButton => _driver.FindElement(MobileBy.ClassName("android.widget.Button"));

		public void MakeCalc(string num1, string num2)
		{
			firstNumInput.Clear();
			firstNumInput.SendKeys(num1);

			secondNumInput.Clear();
			secondNumInput.SendKeys(num2);

			actions.MoveToElement(calcButton)
				.Click()
				.Perform();
		}

		public void AssertResult(string result)
		{
			Assert.That(resultField.Text, Is.EqualTo(result));
		}
	}
}
