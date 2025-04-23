using ColorNoteTests.Pages;
using OpenQA.Selenium.Appium.Android;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorNoteTests.Tests
{
	public class CreateNoteTests : BaseTest
	{
		[SetUp]
		public void SetUp()
		{
			_driver = new AndroidDriver(_service.ServiceUrl, androidOptions);
			_driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);

			_tutorialPage = new TutorialPage(_driver);
			_homePage = new HomePage(_driver);
			_textNotePage = new TextNotePage(_driver);
		}

		[TearDown]
		public void TearDown()
		{
			_driver.Quit();
			_driver.Dispose();
		}

		[Test]
		public void CreateNoteWithValidData()
		{
			string title = GenerateRandomTitle();
			_tutorialPage.SkipButton.Click();

			_homePage.CreateNoteBtn.Click();
			_homePage.TextNoteOption.Click();

			_textNotePage.TitleField.SendKeys(title);
			_textNotePage.NoteField.SendKeys("Some text for test...");
			_textNotePage.DoneBtn.Click();
			_textNotePage.BackBtn.Click();

			var lastCreatedNoteTitle = _homePage.TextNotes.First().Text;
			Assert.That(lastCreatedNoteTitle, Is.EqualTo(title));
		}
	}
}
