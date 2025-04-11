using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodyTestsPOM.Pages
{
	public class EditFoodPage : BasePage
	{
		public EditFoodPage(IWebDriver drv) : base(drv) { }

		public IWebElement FoodNameField => driver.FindElement(By.Name("Name"));

		public IWebElement AddButton => driver.FindElement(By.XPath("//button[@type='submit']"));

		public void EditFoodTitle(string newTitle)
		{
			FoodNameField.Clear();
			FoodNameField.SendKeys(newTitle);
			
			AddButton.Click();
		}
	}
}
