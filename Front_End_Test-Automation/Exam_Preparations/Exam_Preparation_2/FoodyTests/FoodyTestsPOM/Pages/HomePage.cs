using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodyTestsPOM.Pages
{
	public class HomePage : BasePage
	{
		public HomePage(IWebDriver drv) : base(drv) { }

		public override string PageUrl => base.PageUrl + "/";

		public ReadOnlyCollection<IWebElement> Foods => wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//div[@class='row gx-5 align-items-center']")));

		public string LastFoodName => Foods.Last()
			.FindElement(By.XPath(".//h2[@class='display-4']"))
			.Text
			.Trim();

		public IWebElement SearchField => driver.FindElement(By.Name("keyword"));

		public IWebElement SearchButton => driver.FindElement(By.XPath("//button[@class='btn btn-primary rounded-pill mt-5 col-2']"));

		public IWebElement NoFoodsMsg => wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//h2[@class='display-4']")));

		public IWebElement AddButton => wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//a[@class='btn btn-primary btn-xl rounded-pill mt-5']")));

		public IWebElement EditButton => Foods.Last()
			.FindElement(By.XPath(".//a[contains(@href, '/Food/Edit')]"));

		public IWebElement DeleteButton => Foods.Last()
			.FindElement(By.XPath(".//a[contains(@href, '/Food/Delete')]"));

		public void AssertNoFoodsMessage()
		{
			Assert.That(NoFoodsMsg.Displayed, Is.True,
				"No Foods message is not visible as expected.");
			Assert.That(NoFoodsMsg.Text, Is.EqualTo("There are no foods :("),
				$"Expected 'No Food Message' text to be 'There are no foods :(', but was {NoFoodsMsg.Text}'");
		}

		public void AssertAddButtonVisibility()
		{
			Assert.That(AddButton.Displayed, Is.True,
				"Add button is not visible as expected.");
		}
	}
}
