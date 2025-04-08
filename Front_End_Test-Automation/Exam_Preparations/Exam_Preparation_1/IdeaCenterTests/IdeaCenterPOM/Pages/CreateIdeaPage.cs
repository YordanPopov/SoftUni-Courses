using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeaCenterPOM.Pages
{
	public class CreateIdeaPage : BasePage
	{
		public CreateIdeaPage(IWebDriver driver) : base(driver) { }

		public override string PageUrl => base.PageUrl + "/Ideas/Create";

		public IWebElement TitleField => driver.FindElement(By.XPath("//input[@name='Title']"));

		public IWebElement DescriptionField => driver.FindElement(By.XPath("//textarea[@name='Description']"));

		public IWebElement CreateButton => driver.FindElement(By.XPath("//button[@class='btn btn-primary btn-lg']"));

		public string MainErrMsg => driver.FindElement(By.XPath("//div[@class='text-danger validation-summary-errors']//li")).Text;
	}
}
