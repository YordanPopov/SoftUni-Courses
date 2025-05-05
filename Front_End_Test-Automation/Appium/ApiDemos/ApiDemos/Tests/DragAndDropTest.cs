using OpenQA.Selenium.Appium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace ApiDemos.Tests
{
	public class DragAndDropTest : BaseTest
	{
		[Test]
		public void Test_DragAndDrop()
		{
			_driver.FindElement(MobileBy.AccessibilityId("Views")).Click();
			_driver.FindElement(MobileBy.AccessibilityId("Drag and Drop")).Click();

			var dragDot = _driver.FindElement(MobileBy.Id("io.appium.android.apis:id/drag_dot_1"));
			var dropDot = _driver.FindElement(MobileBy.Id("io.appium.android.apis:id/drag_dot_2"));

			var scriptArgs = new Dictionary<string, object>
			{
				{ "elementId", dragDot.Id },
				{ "endX", dropDot.Location.X + (dropDot.Size.Width / 2) },
				{ "endY", dropDot.Location.Y + (dropDot.Size.Height /2)},
				{ "speed", 2500 }
			};
			_driver.ExecuteScript("mobile: dragGesture", scriptArgs);

			var dropSuccessMessage = _driver.FindElement(MobileBy.Id("io.appium.android.apis:id/drag_result_text"));
			Assert.That(dropSuccessMessage.Text, Is.EqualTo("Dropped!"));
		}
	}
}
