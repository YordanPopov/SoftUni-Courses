using ApiDemos.Config;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Service;

namespace ApiDemos.Drivers
{
	public class DriverFactory
	{
		private static AppiumLocalService _service;

		public static AndroidDriver CreateDriver()
		{
			var config = ConfigReader.GetConfig();

			_service = new AppiumServiceBuilder()
				.WithIPAddress("127.0.0.1")
				.UsingPort(4723)
				.Build();
			_service.Start();

			var options = new AppiumOptions()
			{
				AutomationName = config.automationName.ToString(),
				PlatformName = config.platformName.ToString(),
				PlatformVersion = config.platformVersion.ToString(),
				DeviceName = config.deviceName.ToString(),
				App = config.app.ToString()
			};

			return new AndroidDriver(_service.ServiceUrl, options);
		}

		public static void StopService()
		{
			if (_service != null && _service.IsRunning)
			{
				_service.Dispose();
			}
		}
	}
}
