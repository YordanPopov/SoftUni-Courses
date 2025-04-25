using ColorNoteTests.Pages;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorNoteTests.Tests
{
	public class EditNoteTests : BaseTest
	{
		private string lastCreatedNoteTitle;
		private string lastCreatedNoteContent;
		[SetUp]
		public void SetUp()
		{
			_driver = new AndroidDriver(_service.ServiceUrl, androidOptions);
			_driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);

			_homePage = new HomePage(_driver);
			_tutorialPage = new TutorialPage(_driver);
			_textNotePage = new TextNotePage(_driver);

			_tutorialPage.SkipButton.Click();

			// Create Note
			lastCreatedNoteTitle = GenerateRandomTitle();
			lastCreatedNoteContent = GenerateRandomContent(15);

			_homePage.CreateNoteBtn.Click();
			_homePage.TextNoteOption.Click();
			_textNotePage.CreateNote(lastCreatedNoteTitle, lastCreatedNoteContent);
		}

		[Test]
		public void EditNoteTitle()
		{
			Assert.That(_homePage.TextNotes.First().Text, Is.EqualTo(lastCreatedNoteTitle));

			string updatedTitle = "EDITED-" + lastCreatedNoteTitle;
			string updatedContent = "EDITED-" + lastCreatedNoteContent;

			_homePage.TextNotes.First().Click();
			var noteContent = _driver.FindElement(MobileBy.Id("com.socialnmobile.dictapps.notepad.color.note:id/view_note"));
			Assert.That(noteContent.Text, Is.EqualTo(lastCreatedNoteContent));

			_textNotePage.EditBtn.Click();
			_textNotePage.TitleField.Clear();
			_textNotePage.TitleField.SendKeys(updatedTitle);
			_textNotePage.DoneBtn.Click();
			_textNotePage.BackBtn.Click();

			Assert.That(_homePage.TextNotes.First().Text, Is.EqualTo(updatedTitle));
		}

		[TearDown]
		public void TearDown()
		{
			_driver.Quit();
			_driver.Dispose();
		}
	}
}
