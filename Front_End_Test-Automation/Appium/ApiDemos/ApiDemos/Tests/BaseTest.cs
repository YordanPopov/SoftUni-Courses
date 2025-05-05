using ApiDemos.Drivers;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium;
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

		public IWebElement ScrollToElement(string selector)
		{
			return _driver.FindElement(MobileBy.AndroidUIAutomator($"new UiScrollable(new UiSelector().scrollable(true)).scrollIntoView({selector})"));
		}

		public void PerformZoom(int startX1, int startY1, int endX1, int endY1, int startX2, int startY2, int endX2, int endY2)
		{
			var finger1 = new PointerInputDevice(PointerKind.Touch);
			var finger2 = new PointerInputDevice(PointerKind.Touch);

			var moveFinger1 = new ActionSequence(finger1);
			var moveFinger2 = new ActionSequence(finger2);

			moveFinger1.AddAction(finger1.CreatePointerMove(CoordinateOrigin.Viewport, startX1, startY1, TimeSpan.Zero));
			moveFinger1.AddAction(finger1.CreatePointerDown(MouseButton.Left));
			moveFinger1.AddAction(finger1.CreatePointerMove(CoordinateOrigin.Viewport, endX1, endY1, TimeSpan.FromMilliseconds(1000)));
			moveFinger1.AddAction(finger1.CreatePointerUp(MouseButton.Left));

			moveFinger2.AddAction(finger2.CreatePointerMove(CoordinateOrigin.Viewport, startX2, startY2, TimeSpan.Zero));
			moveFinger2.AddAction(finger2.CreatePointerDown(MouseButton.Left));
			moveFinger2.AddAction(finger2.CreatePointerMove(CoordinateOrigin.Viewport, endX2, endY2, TimeSpan.FromMilliseconds(1000)));
			moveFinger2.AddAction(finger2.CreatePointerUp(MouseButton.Left));

			_driver.PerformActions(new List<ActionSequence> { moveFinger1, moveFinger2 });
		}
	}
}
