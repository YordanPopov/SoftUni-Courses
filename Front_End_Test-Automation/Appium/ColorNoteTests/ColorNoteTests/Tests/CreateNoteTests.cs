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

			_tutorialPage.SkipButton.Click();
		}

		[Test]
		public void CreateNoteWithValidData()
		{
			string title = GenerateRandomTitle();

			_homePage.CreateNoteBtn.Click();
			_homePage.TextNoteOption.Click();

			_textNotePage.TitleField.SendKeys(title);
			_textNotePage.NoteField.SendKeys("Some text for test...");
			_textNotePage.DoneBtn.Click();
			_textNotePage.BackBtn.Click();

			Assert.That(_homePage.TextNotes.First().Text, Is.EqualTo(title));
		}

		[Test]
		public void CreateNoteWithoutContent()
		{
			string title = GenerateRandomTitle();

			_homePage.CreateNoteBtn.Click();
			_homePage.TextNoteOption.Click();

			_textNotePage.TitleField.SendKeys(title);
			_textNotePage.DoneBtn.Click();
			_textNotePage.BackBtn.Click();

			Assert.That(_homePage.TextNotes.First().Text, Is.EqualTo(title));
		}

		[Test]
		public void CreateNoteWithoutTitle()
		{
			string content = "This is some content for testing...";

			_homePage.CreateNoteBtn.Click();
			_homePage.TextNoteOption.Click();

			_textNotePage.NoteField.SendKeys(content);
			_textNotePage.DoneBtn.Click();
			_textNotePage.BackBtn.Click();

			Assert.That(_homePage.TextNotes.First().Text, Does.Contain(content));
		}

		[Test]
		public void CreateNoteWithEmptySpaces()
		{
			_homePage.CreateNoteBtn.Click();
			_homePage.TextNoteOption.Click();

			_textNotePage.TitleField.SendKeys(" ");
			_textNotePage.NoteField.SendKeys(" ");
			_textNotePage.DoneBtn.Click();
			_textNotePage.BackBtn.Click();

			var today = DateTime.Now.ToString("M/d/yy");
			Assert.That(_homePage.TextNotes.First().Text, Is.EqualTo($"({today})"));
		}

		[Test]
		public void CreateValidNoteUsingAddNoteButton()
		{
			string title = GenerateRandomTitle();

			_homePage.AddNoteBtn.Click();
			_homePage.TextNoteOption.Click();

			_textNotePage.TitleField.SendKeys(title);
			_textNotePage.NoteField.SendKeys("Some content...");
			_textNotePage.DoneBtn.Click();
			_textNotePage.BackBtn.Click();

			Assert.That(_homePage.TextNotes.First().Text, Is.EqualTo(title));
		}

		[Test]
		public void CreateNotesWithVariousColors()
		{
			//To-Do
		}

		[TearDown]
		public void TearDown()
		{
			_driver.Quit();
			_driver.Dispose();
		}
	}
}
