using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamTests.Pages
{
	public class AllMoviesPage : BasePage
	{
		public AllMoviesPage(IWebDriver driver) : base(driver)
		{

		}

		public override string PageUrl => base.PageUrl + "/Catalog/All#all";

		public IReadOnlyCollection<IWebElement> PageNumbers => _driver.FindElements(By.XPath("//a[@class='page-link']"));

		public IReadOnlyCollection<IWebElement> Movies => _wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//div[@class='col-lg-4']")));

		public IWebElement LastMovieTitle => Movies.Last().FindElement(By.XPath(".//h2"));

		public IWebElement LastMovieEditButton => Movies.Last().FindElement(By.XPath(".//a[contains(@href, '/Movie/Edit')]"));

		public IWebElement LastMovieDeleteButton => Movies.Last().FindElement(By.XPath(".//a[contains(@href, '/Movie/Delete')]"));

		public IWebElement MarkAsWatchedButton => Movies.Last().FindElement(By.XPath(".//a[contains(@href, '/Movie/MarksAsWatched')]"));

		public void NavigateToLastPage()
		{
			actions.MoveToElement(PageNumbers.Last())
				.Click()
				.Perform();
		}
	}
}
