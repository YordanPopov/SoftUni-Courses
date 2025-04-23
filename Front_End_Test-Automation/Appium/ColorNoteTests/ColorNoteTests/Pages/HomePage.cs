using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorNoteTests.Pages
{
	public class HomePage : BasePage
	{
		public HomePage(AndroidDriver driver) : base(driver)
		{

		}

		public AppiumElement MainMenuBtn => _driver.FindElement(MobileBy.Id("com.socialnmobile.dictapps.notepad.color.note:id/main_btn3"));

		public AppiumElement SettingsMenuBtn => _driver.FindElement(MobileBy.Id("com.socialnmobile.dictapps.notepad.color.note:id/icon_nav"));

		public AppiumElement CreateNoteBtn => _driver.FindElement(MobileBy.Id("com.socialnmobile.dictapps.notepad.color.note:id/main_btn1"));

		public AppiumElement SearchBtn => _driver.FindElement(MobileBy.Id("com.socialnmobile.dictapps.notepad.color.note:id/main_btn2"));

		public AppiumElement CentralMenuBtn => _driver.FindElement(MobileBy.Id("com.socialnmobile.dictapps.notepad.color.note:id/text_button_center"));

		public AppiumElement AddNoteBtn => _driver.FindElement(MobileBy.Id("com.socialnmobile.dictapps.notepad.color.note:id/img_add"));

		public AppiumElement TextNoteOption => _driver.FindElement(MobileBy.AndroidUIAutomator("new UiSelector().text(\"Text\")"));

		public AppiumElement ChecklistOption => _driver.FindElement(MobileBy.AndroidUIAutomator("new UiSelector().text(\"Checklist\")"));

		public IReadOnlyCollection<AppiumElement> TextNotes => _driver.FindElements(MobileBy.Id("com.socialnmobile.dictapps.notepad.color.note:id/title"));
	}
}
