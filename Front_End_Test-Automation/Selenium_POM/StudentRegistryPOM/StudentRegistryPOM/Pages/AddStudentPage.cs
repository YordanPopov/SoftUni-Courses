using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistryPOM.Pages
{
	public class AddStudentPage : BasePage
	{
		public AddStudentPage(IWebDriver driver) : base(driver) { }

		public override string PageUrl => "http://localhost:8080/add-student";

		public IWebElement ElementErrorMsg => _driver.FindElement(By.XPath("//body/div"));

		public IWebElement FieldStudentName => _driver.FindElement(By.Id("name"));
		public IWebElement FieldStudentEmail => _driver.FindElement(By.Id("email"));
		public IWebElement AddButton => _driver.FindElement(By.TagName("button"));

		public void AddStudent(string name, string email)
		{
			FieldStudentName.SendKeys(name);
			FieldStudentEmail.SendKeys(email);
			AddButton.Click();
		}

		public string GetErrorMsg()
		{
			return ElementErrorMsg.Text;
		}
	}
}
