using ApiDemos.Drivers;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Interactions;

namespace ApiDemos.Tests
{
	public class BaseTest
	{
		protected AndroidDriver _driver;

		protected Actions _actions;

		[OneTimeSetUp]
		public void OneTimeSetUp()
		{
			_driver = DriverFactory.CreateDriver();
		}

		[OneTimeTearDown]
		public void OneTimeTearDown()
		{
			_driver.Quit();
			_driver.Dispose();
			DriverFactory.StopService();
		}
	}
}
