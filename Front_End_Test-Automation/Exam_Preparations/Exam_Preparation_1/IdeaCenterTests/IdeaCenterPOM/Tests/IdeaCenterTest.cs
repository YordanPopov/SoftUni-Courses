using IdeaCenterPOM.Pages;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeaCenterPOM.Tests
{
	[TestFixture]
	public class IdeaCenterTest : BaseTest
	{
		private static string lastCreatedIdeaTitle;
		private static string lastCreatedIdeaDesc;

		[Test, Order(1)]
		public void Test_CreateIdeaWithInvalidData()
		{
			createIdeaPage.OpenPage();
			createIdeaPage.TitleField.SendKeys("");
			createIdeaPage.DescriptionField.SendKeys("");
			createIdeaPage.CreateButton.Click();

			Assert.That(wait.Until(ExpectedConditions.UrlContains("/Ideas/Create")), Is.True);
			Assert.That(createIdeaPage.MainErrMsg, Is.EqualTo("Unable to create new Idea!"));
		}

		[Test, Order(2)]
		public void Test_CreateIdeaWithRandomData()
		{
			lastCreatedIdeaTitle = "testTitle_" + GenerateRandomString(4);
			lastCreatedIdeaDesc = "testDescription_" + GenerateRandomString(4);

			createIdeaPage.OpenPage();
			createIdeaPage.TitleField.SendKeys(lastCreatedIdeaTitle);
			createIdeaPage.DescriptionField.SendKeys(lastCreatedIdeaDesc);
			createIdeaPage.CreateButton.Click();

			Assert.That(wait.Until(ExpectedConditions.UrlContains("/Ideas/MyIdeas")));
			Assert.That(myIdeasPage.IdeasDescription, Is.EqualTo(lastCreatedIdeaDesc));
		}

		[Test, Order(3)]
		public void Test_ViewLastCreatedIdea()
		{
			myIdeasPage.OpenPage();
			actions.MoveToElement(myIdeasPage.ViewButton)
				.Click()
				.Perform();

			string expectedTitle = driver.FindElement(By.XPath("//div[@id='intro']/h1")).Text;
			Assert.That(expectedTitle, Is.EqualTo(lastCreatedIdeaTitle));
		}
	}
}
