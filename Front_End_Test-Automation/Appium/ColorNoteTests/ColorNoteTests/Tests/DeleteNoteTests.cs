using ColorNoteTests.Pages;
using OpenQA.Selenium.Appium.Android;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorNoteTests.Tests
{
	public class DeleteNoteTests : BaseTest
	{
		[SetUp]
		public void SetUp()
		{
			_driver = new AndroidDriver(_service.ServiceUrl, androidOptions);
			_driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);

			_homePage = new HomePage(_driver);
			_tutorialPage = new TutorialPage(_driver);
			_textNotePage = new TextNotePage(_driver);

			_tutorialPage.SkipButton.Click();
			_homePage.CreateNoteBtn.Click();
			_homePage.TextNoteOption.Click();

			_textNotePage.CreateNote(GenerateRandomTitle(), GenerateRandomContent(20));
		}

		[Test]
		public void DeleteNote()
		{
			_homePage.TextNotes.First().Click();

			_textNotePage.MenuBtn.Click();
			_textNotePage.DeleteBtn.Click();

			Assert.That(_textNotePage.AlertText, Is.EqualTo("Delete"));
			Assert.That(_textNotePage.ConfirmationMessage, Is.EqualTo("Are you sure you want to move the note to the trash can?"));
			_textNotePage.OkayBtn.Click();

			Assert.That(_homePage.TextNotes.Any(), Is.False);
		}

		[TearDown]
		public void TearDown()
		{
			_driver.Quit();
			_driver.Dispose();
		}
	}
}
