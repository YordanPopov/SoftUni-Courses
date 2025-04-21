using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorNoteTests.Pages
{
	public class TutorialPage : BasePage
	{
		public TutorialPage(AndroidDriver driver) : base(driver)
		{

		}

		public AppiumElement SkipButton => _driver.FindElement(MobileBy.Id("com.socialnmobile.dictapps.notepad.color.note:id/btn_start_skip"));

		public AppiumElement StartButton => _driver.FindElement(MobileBy.Id("com.socialnmobile.dictapps.notepad.color.note:id/btn_start"));

		public AppiumElement NextButton => _driver.FindElement(MobileBy.Id("com.socialnmobile.dictapps.notepad.color.note:id/btn_next"));

		public string Title => _wait.Until(ExpectedConditions.ElementIsVisible(MobileBy.Id("com.socialnmobile.dictapps.notepad.color.note:id/textTitle"))).Text;

		public string Subtitle => _wait.Until(ExpectedConditions.ElementIsVisible(MobileBy.Id("com.socialnmobile.dictapps.notepad.color.note:id/textSubtitle"))).Text;
	}
}
