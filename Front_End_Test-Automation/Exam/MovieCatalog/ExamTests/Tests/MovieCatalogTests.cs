using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamTests.Tests
{
	public class MovieCatalogTests : BaseTest
	{
		private string ? lastCreatedMovieTitle;
		private string ? lastCreatedMovieDescription;

		[SetUp]
		public void SetUp()
		{
			_driver.Navigate().GoToUrl(_homePage.PageUrl);
		}

		[Test, Order(1)]
		public void Test_AddMovieWithoutTitle()
		{
			_addMoviePage.OpenPage();

			_addMoviePage.TitleField.Clear();

			actions.MoveToElement(_addMoviePage.AddButton)
				.Click()
				.Perform();

			Assert.That(_addMoviePage.ErrorMessage.Text.Trim(), Is.EqualTo("The Title field is required."),
				"Expected validation message for missing title was not displayed.");
		}

		[Test, Order(2)]
		public void Test_AddMovieWithoutDescription()
		{
			string movieTitle = $"TITLE-{GenerateRandomString(5)}";

			_addMoviePage.OpenPage();

			_addMoviePage.TitleField.Clear();
			_addMoviePage.TitleField.SendKeys(movieTitle);
			_addMoviePage.DescriptionField.Clear();

			actions.MoveToElement(_addMoviePage.AddButton)
				.Click()
				.Perform();

			Assert.That(_addMoviePage.ErrorMessage.Text.Trim(), Is.EqualTo("The Description field is required."),
				"Expected validation message for missing description was not displayed.");
		}

		[Test, Order(3)]
		public void Test_AddMovieWithRandomData()
		{
			lastCreatedMovieTitle = $"TITLE-{GenerateRandomString(3)}";
			lastCreatedMovieDescription = $"DESCRIPTION-{GenerateRandomString(3)}";

			_addMoviePage.OpenPage();

			_addMoviePage.TitleField.Clear();
			_addMoviePage.TitleField.SendKeys(lastCreatedMovieTitle);

			_addMoviePage.DescriptionField.Clear();
			_addMoviePage.DescriptionField.SendKeys(lastCreatedMovieDescription);

			actions.MoveToElement(_addMoviePage.AddButton)
				.Click()
				.Perform();

			_allMoviesPage.NavigateToLastPage();

			string lastMovieTitle = _allMoviesPage.LastMovieTitle.Text.Trim();
			Assert.That(lastMovieTitle, Is.EqualTo(lastCreatedMovieTitle),
				$"Expected last movie title to be '{lastCreatedMovieTitle}', but was '{lastMovieTitle}'.");
		}

		[Test, Order(4)]
		public void Test_EditLastAddedMovieTitle()
		{
			string updatedTitle = $"EDITED-{lastCreatedMovieTitle}";

			_allMoviesPage.OpenPage();
			_allMoviesPage.NavigateToLastPage();
			_allMoviesPage.LastMovieEditButton.Click();
		
			_editMoviePage.TitleField.Clear();
			_editMoviePage.TitleField.SendKeys(updatedTitle);
			actions.MoveToElement(_editMoviePage.EditButton)
				.Click()
				.Perform();

			Assert.That(_editMoviePage.SuccessMesssage.Text.Trim(), Is.EqualTo("The Movie is edited successfully!"),
				"Edit success message not shown after updating movie title.");
			lastCreatedMovieTitle = updatedTitle;
		}

		[Test, Order(5)]
		public void Test_MarkLastAddedMovieAsWatched()
		{
			_allMoviesPage.OpenPage();
			_allMoviesPage.NavigateToLastPage();
			_allMoviesPage.MarkAsWatchedButton.Click();

			_watchedMoviesPage.OpenPage();
			_watchedMoviesPage.NavigateToLastPage();

			Assert.That(_watchedMoviesPage.LastMovieTitle.Text.Trim(), Is.EqualTo(lastCreatedMovieTitle),
				$"Expected watched movie title to be '{lastCreatedMovieTitle}', but it was different.");
		}

		[Test, Order(6)]
		public void Test_DeleteLastAddedMovie()
		{
			_allMoviesPage.OpenPage();
			_allMoviesPage.NavigateToLastPage();
			_allMoviesPage.LastMovieDeleteButton.Click();

			_deleteMoviePage.YesButton.Click();

			Assert.That(_deleteMoviePage.SuccessMessage.Text.Trim(), Is.EqualTo("The Movie is deleted successfully!"), "Success message after movie deletion was not displayed as expected.");
		}
	}
}
