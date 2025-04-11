using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V133.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodyTestsPOM.Pages
{
	public class AddFoodPage : BasePage
	{
		public AddFoodPage(IWebDriver drv) : base(drv) { }

		public override string PageUrl => base.PageUrl + "/Food/Add";

		public IWebElement FoodNameField => driver.FindElement(By.Name("Name"));

		public IWebElement FoodDescField => driver.FindElement(By.Name("Description"));

		public IWebElement FoodImgField => driver.FindElement(By.Name("Url"));

		public IWebElement AddButton => driver.FindElement(By.XPath("//button[@type='submit']"));

		public IWebElement MainErrorMsg => driver.FindElement(By.XPath("//div[@class='text-danger validation-summary-errors']/ul/li"));

		public void AddFood(string foodName, string desc, string imgUrl)
		{
			FoodNameField.Clear();
			FoodNameField.SendKeys(foodName);

			FoodDescField.Clear();
			FoodDescField.SendKeys(desc);

			FoodImgField.Clear();
			FoodImgField.SendKeys(imgUrl);

			AddButton.Click();
		}

		public void AssertMainErrorMessage()
		{
			Assert.That(MainErrorMsg.Text.Trim(), Is.EqualTo("Unable to add this food revue!"));
		}
	}
}
