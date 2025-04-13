using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamTests.Pages
{
	public class DeleteMoviePage : BasePage
	{
		public DeleteMoviePage(IWebDriver driver) : base(driver)
		{

		}

		public IWebElement YesButton => _driver.FindElement(By.XPath("//button[@class='btn warning' and text()='Yes']"));

		public IWebElement NoButton => _driver.FindElement(By.XPath("//a[@class='btn btn-success' and text()='No']"));

		public IWebElement SuccessMessage => _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='toast-message']")));
	}
}
