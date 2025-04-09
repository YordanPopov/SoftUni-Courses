using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeaCenterPOM.Pages
{
	public class EditIdeaPage : BasePage
	{
		public EditIdeaPage(IWebDriver driver) : base(driver) { }

		public IWebElement TitleField => driver.FindElement(By.XPath("//input[@name='Title']"));

		public IWebElement DescriptionField => driver.FindElement(By.XPath("//textarea[@name='Description']"));

		public IWebElement EditButton => driver.FindElement(By.XPath("//button[@class='btn btn-primary btn-lg']"));
	}
}
