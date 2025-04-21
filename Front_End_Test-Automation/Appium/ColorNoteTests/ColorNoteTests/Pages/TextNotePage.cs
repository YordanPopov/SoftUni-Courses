using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorNoteTests.Pages
{
	public class TextNotePage : BasePage
	{
		public TextNotePage(AndroidDriver driver) : base(driver)
		{

		}

		public AppiumElement DoneBtn => _driver.FindElement(MobileBy.Id("com.socialnmobile.dictapps.notepad.color.note:id/back_btn"));

		public AppiumElement TitleField => _driver.FindElement(MobileBy.Id("com.socialnmobile.dictapps.notepad.color.note:id/edit_title"));

		public AppiumElement ColorBtn => _driver.FindElement(MobileBy.Id("com.socialnmobile.dictapps.notepad.color.note:id/color_btn"));

		public IReadOnlyCollection<AppiumElement> Colors => (IReadOnlyCollection<AppiumElement>)_wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(MobileBy.ClassName("android.widget.FrameLayout")));

		public AppiumElement MenuBtn => _driver.FindElement(MobileBy.Id("com.socialnmobile.dictapps.notepad.color.note:id/menu_btn"));

		public AppiumElement NoteField => _driver.FindElement(MobileBy.Id("com.socialnmobile.dictapps.notepad.color.note:id/edit_note"));

		public AppiumElement UndoBtn => _driver.FindElement(MobileBy.Id("com.socialnmobile.dictapps.notepad.color.note:id/btn_undo"));

		public AppiumElement RedoBtn => _driver.FindElement(MobileBy.Id("com.socialnmobile.dictapps.notepad.color.note:id/btn_redo"));
	}
}
