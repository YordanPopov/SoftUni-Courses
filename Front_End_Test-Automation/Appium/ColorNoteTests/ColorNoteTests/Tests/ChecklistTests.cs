using ColorNoteTests.Pages;
using OpenQA.Selenium.Appium.Android;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorNoteTests.Tests
{
	public class ChecklistTests : BaseTest
	{
		[SetUp]
		public void SetUp()
		{
			_driver = new AndroidDriver(_service.ServiceUrl, androidOptions);
			_driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);

			_tutorialPage = new TutorialPage(_driver);
			_homePage = new HomePage(_driver);
			_textNotePage = new TextNotePage(_driver);
			_checklistPage = new ChecklistPage(_driver);
		}

		[TearDown]
		public void TearDown()
		{
			_driver.Quit();
			_driver.Dispose();
		}
	}
}
