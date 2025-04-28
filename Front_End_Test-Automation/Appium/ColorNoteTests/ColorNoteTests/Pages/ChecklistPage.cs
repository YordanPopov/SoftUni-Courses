using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorNoteTests.Pages
{
	public class ChecklistPage : BasePage
	{
		public ChecklistPage(AndroidDriver driver) : base(driver)
		{

		}

		public AppiumElement AddItemBtn => _driver.FindElement(MobileBy.AndroidUIAutomator("new UiSelector().resourceId(\"com.socialnmobile.dictapps.notepad.color.note:id/icon\").instance(0)"));

		public AppiumElement TextField => _driver.FindElement(MobileBy.AndroidUIAutomator("new UiSelector().resourceId(\"com.socialnmobile.dictapps.notepad.color.note:id/icon\").instance(0)"));

		public AppiumElement OkayBtn => _driver.FindElement(MobileBy.Id("android:id/button1"));

		public AppiumElement CancelBtn => _driver.FindElement(MobileBy.Id("android:id/button2"));

		public AppiumElement NextBtn => _driver.FindElement(MobileBy.Id("android:id/button3"));

		public IReadOnlyCollection<AppiumElement> Items => _driver.FindElements(MobileBy.XPath("//android.widget.TextView[@resource-id=\"com.socialnmobile.dictapps.notepad.color.note:id/text\" and contains(@text, \"ITEM\")]"));
	}
}
