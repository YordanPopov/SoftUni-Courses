using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Interactions;

namespace ApiDemos.Tests
{
	public class SwipeTest : BaseTest
	{
		[Test]
		public void Test_Swipe()
		{
			_actions = new Actions(_driver);

			_driver.FindElement(MobileBy.AccessibilityId("Views")).Click();
			_driver.FindElement(MobileBy.AccessibilityId("Gallery")).Click();
			_driver.FindElement(MobileBy.AccessibilityId("1. Photos")).Click();

			var firstImage = _driver.FindElements(MobileBy.ClassName("android.widget.ImageView"))[0];
			
			_actions.ClickAndHold(firstImage)
				.MoveByOffset(-500, 0)
				.Build()
				.Perform();

			var thirdImage = _driver.FindElements(MobileBy.ClassName("android.widget.ImageView"))[2];
			Assert.That(thirdImage, Is.Not.Null);
		}
	}
}
