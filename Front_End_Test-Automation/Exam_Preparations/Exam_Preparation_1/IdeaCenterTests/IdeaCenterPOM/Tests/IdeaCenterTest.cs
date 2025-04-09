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
			createIdeaPage.CreateIdea("", "");

			Assert.That(wait.Until(ExpectedConditions.UrlContains("/Ideas/Create")), Is.True);
			Assert.That(createIdeaPage.MainErrMsg, Is.EqualTo("Unable to create new Idea!"));
		}

		[Test, Order(2)]
		public void Test_CreateIdeaWithRandomData()
		{
			lastCreatedIdeaTitle = "testTitle_" + GenerateRandomString(4);
			lastCreatedIdeaDesc = "testDescription_" + GenerateRandomString(4);

			createIdeaPage.CreateIdea(lastCreatedIdeaTitle, lastCreatedIdeaDesc);

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

		[Test, Order(4)]
		public void Test_EditLastCreatedIdeaTitle()
		{
			myIdeasPage.OpenPage();
			actions.MoveToElement(myIdeasPage.EditButton)
				.Click()
				.Perform();

			lastCreatedIdeaTitle = "Changed Title: " + lastCreatedIdeaTitle;

			editIdeaPage.TitleField.Clear();
			editIdeaPage.TitleField.SendKeys(lastCreatedIdeaTitle);
			actions.MoveToElement(editIdeaPage.EditButton)
				.Click()
				.Perform();

			actions.MoveToElement(myIdeasPage.ViewButton)
				.Click()
				.Perform();

			Assert.That(viewIdeaPage.IdeaTitle, Is.EqualTo(lastCreatedIdeaTitle));
		}

		[Test, Order(5)]
		public void Test_EditIdeaDescription()
		{
			myIdeasPage.OpenPage();
			actions.MoveToElement(myIdeasPage.EditButton)
				.Click()
				.Perform();

			lastCreatedIdeaDesc = "Changed Description: " + lastCreatedIdeaDesc;
			editIdeaPage.DescriptionField.Clear();
			editIdeaPage.DescriptionField.SendKeys(lastCreatedIdeaDesc);
			actions.MoveToElement(editIdeaPage.EditButton)
				.Click()
				.Perform();

			actions.MoveToElement(myIdeasPage.ViewButton)
				.Click()
				.Perform();

			Assert.That(viewIdeaPage.IdeaDescription, Is.EqualTo(lastCreatedIdeaDesc));
		}

		[Test, Order(6)]
		public void Test_DeleteLastCreatedIdea()
		{
			myIdeasPage.OpenPage();
			actions.MoveToElement(myIdeasPage.DeleteButton)
				.Click()
				.Perform();

			if (myIdeasPage.Ideas.Count > 0)
			{
				bool isIdeaDeleted = myIdeasPage.Ideas.All(idea => !idea.Text.Contains(lastCreatedIdeaDesc));
				Assert.That(isIdeaDeleted, Is.True);
			}
			else
			{
				string noIdeasMsg = driver.FindElement(By.XPath("//div[@class='row text-center']/span"))
					.Text
					.Trim();
				Assert.That(noIdeasMsg, Is.EqualTo("No Ideas yet!"));
			}
		}
	}
}
