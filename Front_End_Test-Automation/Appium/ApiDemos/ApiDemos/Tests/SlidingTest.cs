using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Interactions;
using System.Drawing;

namespace ApiDemos.Tests
{
	public class SlidingTest : BaseTest
	{
		[Test]
		public void Test_Slide()
		{
			_driver.FindElement(MobileBy.AccessibilityId("Views")).Click();

			string selector = "new UiSelector().text(\"Seek Bar\")";
			ScrollToElement(selector);

			_driver.FindElement(MobileBy.AccessibilityId("Seek Bar")).Click();
			MoveSeekBarWithInspectorCoordinates(546, 315, 1040, 315);

			var progressResult = _driver.FindElement(MobileBy.Id("io.appium.android.apis:id/progress"));
			Assert.That(progressResult.Text, Is.EqualTo("100 from touch=true"));
		}

		private void MoveSeekBarWithInspectorCoordinates(int startX, int startY, int endX, int endY)
		{
			var touch = new PointerInputDevice(PointerKind.Touch);
			var startPoint = new Point(startX, startY);
			var endPoint = new Point(endX, endY);
			var swipe = new ActionSequence(touch);

			swipe.AddAction(touch.CreatePointerMove(CoordinateOrigin.Viewport, startPoint.X, startPoint.Y, TimeSpan.Zero));
			swipe.AddAction(touch.CreatePointerDown(MouseButton.Left));

			swipe.AddAction(touch.CreatePointerMove(CoordinateOrigin.Viewport, endPoint.X, endPoint.Y, TimeSpan.FromMilliseconds(1000)));
			swipe.AddAction(touch.CreatePointerUp(MouseButton.Left));

			_driver.PerformActions(new List<ActionSequence> { swipe });
		}
	}
}
