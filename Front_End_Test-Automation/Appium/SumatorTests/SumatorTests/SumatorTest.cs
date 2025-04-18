using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumatorTests
{
	[TestFixture]
	public class SumatorTest
	{
		private AndroidDriver driver;
		private AppiumLocalService appiumLocalService;

		[OneTimeSetUp]
		public void OneTimeSetUp()
		{
			appiumLocalService = new AppiumServiceBuilder()
				.WithIPAddress("127.0.0.1")
				.UsingPort(4723)
				.Build();
			appiumLocalService.Start();

			var androidOptions = new AppiumOptions();
			androidOptions.PlatformName = "Android";
			androidOptions.DeviceName = "AndroidDevice";
			androidOptions.PlatformVersion = "16";
			androidOptions.AutomationName = "UiAutomator2";
			androidOptions.App = "D:\\SoftUni\\Front-End-Testing\\Front-End-Test-Automation-Feb-2025\\Appium\\AppiumLab\\com.example.androidappsummator.apk";

			driver = new AndroidDriver(appiumLocalService.ServiceUrl, androidOptions);
		}

		[TestCase("0", "0", "0")]
		[TestCase("10", "10", "20")]
		[TestCase("-10", "-10", "-20")]
		[TestCase("-10", "10", "0")]
		public void Test_WithValidData(string num1, string num2, string result)
		{
			AppiumElement firstNumInput = driver.FindElement(MobileBy.Id("com.example.androidappsummator:id/editText1"));
			firstNumInput.Clear();
			firstNumInput.SendKeys(num1);

			AppiumElement secondNumInput = driver.FindElement(MobileBy.Id("com.example.androidappsummator:id/editText2"));
			secondNumInput.Clear();
			secondNumInput.SendKeys(num2);

			driver.FindElement(MobileBy.Id("com.example.androidappsummator:id/buttonCalcSum")).Click();

			string resultField = driver.FindElement(MobileBy.Id("com.example.androidappsummator:id/editTextSum")).Text;
			Assert.That(resultField, Is.EqualTo(result));
		}

		[OneTimeTearDown]
		public void OneTimeTearDown()
		{
			driver.Quit();
			driver.Dispose();
			appiumLocalService.Dispose();
		}
	}
}
