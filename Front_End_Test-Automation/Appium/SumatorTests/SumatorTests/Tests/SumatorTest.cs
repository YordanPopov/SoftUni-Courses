using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Service;
using SumatorTests.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumatorTests.Tests
{
	[TestFixture]
	public class SumatorTest
	{
		private AndroidDriver driver;

		private AppiumLocalService appiumLocalService;

		protected SummatorPage summator;

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
			summator = new SummatorPage(driver);
		}

		[TestCase("0", "0", "0")]
		[TestCase("10", "10", "20")]
		[TestCase("-10", "-10", "-20")]
		[TestCase("-10", "10", "0")]
		[TestCase("10", "-10", "0")]
		public void Test_Summator_WithIntegerNumbers(string num1, string num2, string expectedResult)
		{
			summator.MakeCalc(num1, num2);
			string actualResult = summator.resultField.Text;

			Assert.That(actualResult, Is.EqualTo(expectedResult));
		}

		[TestCase("0.1", "0.1", "0.2")]
		[TestCase("-0.11", "0.254", "0.144")]
		[TestCase("0.989", "0.4763", "1.4653")]
		[TestCase("0.99", "0.01", "1.00")]
		[TestCase("0.99", "0.1", "1.09")]
		[TestCase("-0.200", "-0.200", "-0.400")]

		public void Test_Summator_WithDecimalNumbers(string num1, string num2, string expectedResult)
		{
			summator.MakeCalc(num1, num2);
			summator.AssertResult(expectedResult);
		}

		[TestCase("invalidNum", "2", "error")]
		[TestCase("invalidNum", "invalidNum", "error")]
		[TestCase("2", "invalidNum", "error")]
		[TestCase("   ", "123", "error")]
		[TestCase("123", "", "error")]
		[TestCase("123", "  ", "error")]
		[TestCase(".", "0.1", "error")]
		[TestCase("1", "!", "error")]
		[TestCase("e2", "2e", "error")]
		public void Test_Summator_WithInvalidData(string num1, string num2, string expectedResult)
		{
			summator.MakeCalc(num1, num2);
			summator.AssertResult(expectedResult);
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
