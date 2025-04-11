using OpenQA.Selenium.Interactions;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodyTestsPOM.Tests
{
	public class FoodyTest : BaseTest
	{
		private string ? lastCreatedFoodName;
		private string ? lastCreatedFoodDescription;

		[SetUp]
		public void SetUp()
		{
			homePage.OpenPage();
		}

		[Test, Order(1)]
		public void Test_AddFoodWithInvalidData()
		{
			addFoodPage.OpenPage();
			addFoodPage.AddFood("", "", "");

			Assert.IsTrue(addFoodPage.IsPageOpened(), "Add Food Page did not open as expected.");
			addFoodPage.AssertMainErrorMessage();
		}

		[Test, Order(2)]
		public void Test_AddFoodWithRandomData()
		{
			homePage.OpenPage();
			addFoodPage.OpenPage();

			lastCreatedFoodName = $"NAME-{GenerateRandomString(5)}";
			lastCreatedFoodDescription = $"DESCRIPTION-{GenerateRandomString(5)}";

			addFoodPage.AddFood(lastCreatedFoodName, lastCreatedFoodDescription, "");

			Assert.IsTrue(homePage.IsPageOpened(), "Home Page did not open as expected.");
			Assert.That(homePage.LastFoodName, Is.EqualTo(lastCreatedFoodName),
				$"Expected last food name to be '{lastCreatedFoodName}', but was '{homePage.LastFoodName}'.");
		}

		[Test, Order(3)]
		public void Test_EditLastAddedFood()
		{
			string updatedTitle = $"UPDATED:{lastCreatedFoodName}";

			homePage.OpenPage();
			actions.MoveToElement(homePage.EditButton)
				.Click()
				.Perform();

			editFoodPage.EditFoodTitle(updatedTitle);

			Assert.That(homePage.LastFoodName, Is.Not.EqualTo(updatedTitle),
				$"Expected last food name to NOT be '{updatedTitle}', but it was.");
			Console.WriteLine("Title remains unchanged due incomplete functionality");
		}

		[Test, Order(4)]
		public void Test_SearchForFoodTitle()
		{   
			homePage.OpenPage();
			homePage.SearchField.SendKeys(lastCreatedFoodName);
			homePage.SearchButton.Click();

			Assert.That(homePage.Foods.Count, Is.EqualTo(1),
				$"Expected exactly 1 food item on the home page, but found {homePage.Foods.Count}.");
			Assert.That(homePage.LastFoodName, Is.EqualTo(lastCreatedFoodName),
				$"Expected last food name to be '{lastCreatedFoodName}', but was '{homePage.LastFoodName}'.");
		}

		[Test, Order(5)]
		public void Test_DeleteLastAddedFood()
		{
			int initialCount = homePage.Foods.Count;

			actions.MoveToElement(homePage.DeleteButton)
				.Click()
				.Perform();

			int countAfterDeletion = homePage.Foods.Count;
			string lastFoodName = homePage.LastFoodName;

			Assert.That(countAfterDeletion, Is.EqualTo(initialCount - 1),
				$"Expected count after deletion to be {initialCount - 1}, but was {countAfterDeletion}");
			Assert.That(lastFoodName, Is.Not.EqualTo(lastCreatedFoodName),
				$"Expected last food item to be different from '{lastCreatedFoodName}', but they are the same.");
		}

		[Test, Order(6)]
		public void Test_SearchForDeletedFood()
		{
			homePage.SearchField.SendKeys(lastCreatedFoodName);
			homePage.SearchButton.Click();

			homePage.AssertNoFoodsMessage();
			homePage.AssertAddButtonVisibility();
		}
	}
}
