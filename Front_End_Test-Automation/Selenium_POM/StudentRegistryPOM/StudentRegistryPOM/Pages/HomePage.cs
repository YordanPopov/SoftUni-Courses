using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistryPOM.Pages
{
	public class HomePage : BasePage
	{
		public HomePage(IWebDriver driver) : base(driver) { }

		public override string PageUrl => "http://localhost:8080/";

		public IWebElement ElementStudentsCount => _driver.FindElement(By.XPath("//b"));

		public int GetStudentCount()
		{
			string studentsCount = ElementStudentsCount.Text;
			return int.Parse(studentsCount);
		}
	}
}
