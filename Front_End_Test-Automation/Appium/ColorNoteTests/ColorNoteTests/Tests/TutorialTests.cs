using ColorNoteTests.Pages;
using OpenQA.Selenium.Appium.Android;

namespace ColorNoteTests.Tests
{
	[TestFixture]
	public class TutorialTests : BaseTest
	{
		[SetUp]
		public void SetUp()
		{
			_driver = new AndroidDriver(_service.ServiceUrl, androidOptions);
			_driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);

			_tutorialPage = new TutorialPage(_driver);
			_textNotePage = new TextNotePage(_driver);
			_homePage = new HomePage(_driver);
		}

		[Test]
		public void VerifyAllNecessaryTutorialSteps()
		{
			Assert.That(_tutorialPage.Title, Is.EqualTo("Welcome to ColorNote"));
			Assert.That(_tutorialPage.Subtitle, Is.EqualTo("Easy to follow step-by-step tutorial"));

			_tutorialPage.StartButton.Click();
			Assert.That(_tutorialPage.Title, Is.EqualTo("Create a note"));
			Assert.That(_tutorialPage.Subtitle, Is.EqualTo("Tap the add button."));

			_tutorialPage.NextButton.Click();
			Assert.That(_tutorialPage.Title, Is.EqualTo("Choose a note type"));
			Assert.That(_tutorialPage.Subtitle, Is.EqualTo("Tap 'Text'."));

			_tutorialPage.NextButton.Click();
			Assert.That(_textNotePage.NoteField.Displayed, Is.True);
		}

		[Test]
		public void VerifySkipTutorialSteps()
		{
			_tutorialPage.SkipTutorial();
			Assert.That(_homePage.CreateNoteBtn.Displayed, Is.True);
		}

		[TearDown]
		public void TearDown()
		{
			_driver.Quit();
			_driver.Dispose();
		}
	}
}
