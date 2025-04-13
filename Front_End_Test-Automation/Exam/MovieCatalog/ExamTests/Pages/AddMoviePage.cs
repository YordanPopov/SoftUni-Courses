using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamTests.Pages
{
	public class AddMoviePage : BasePage
	{
		public AddMoviePage(IWebDriver driver) : base(driver)
		{

		}

		public override string PageUrl => base.PageUrl + "/Catalog/Add#add";

		public IWebElement TitleField => _driver.FindElement(By.XPath("//input[@name='Title']"));

		public IWebElement DescriptionField => _driver.FindElement(By.XPath("//textarea[@name='Description']"));

		public IWebElement AddButton => _driver.FindElement(By.XPath("//button[@class='btn warning']"));

		public IWebElement ErrorMessage => _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='toast-message']")));
	}
}
