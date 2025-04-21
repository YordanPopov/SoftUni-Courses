using ColorNoteTests.Pages;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Service;

namespace ColorNoteTests.Tests
{
	public class BaseTest
	{
		protected AndroidDriver _driver;

		protected AppiumLocalService _service;

		protected AppiumOptions androidOptions;

		public TutorialPage _tutorialPage;

		public TextNotePage _textNotePage;

		[OneTimeSetUp]
		public void OneTimeSetUp()
		{
			_service = new AppiumServiceBuilder()
				.WithIPAddress("127.0.0.1")
				.UsingPort(4723)
				.Build();
			_service.Start();

			androidOptions = new AppiumOptions
			{
				AutomationName = "UiAutomator2",
				PlatformName = "Android",
				PlatformVersion = "16",
				DeviceName = "AndroidDevice",
				App = "D:\\SoftUni\\Front-End-Testing\\Front-End-Test-Automation-Feb-2025\\Appium\\Appium-Exercise\\Resources\\Notepad.apk"
			};
			androidOptions.AddAdditionalAppiumOption("autoGrantPermissions", true);
		}

		[OneTimeTearDown]
		public void OneTimeTearDown()
		{ 
			_service.Dispose();
		}
	}
}
