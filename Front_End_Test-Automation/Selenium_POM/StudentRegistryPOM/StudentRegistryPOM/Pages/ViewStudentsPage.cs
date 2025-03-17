using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistryPOM.Pages
{
	public class ViewStudentsPage : BasePage
	{
		public ViewStudentsPage(IWebDriver driver) : base(driver) { }

		public override string PageUrl => "http://localhost:8080/students";

		public ReadOnlyCollection<IWebElement> ListItemsStudents => _driver.FindElements(By.XPath("//ul//li"));

		public string[] GetStudentsList()
		{
			string[] listStudents = ListItemsStudents.Select(s => s.Text).ToArray();
			return listStudents;
		}
	}
}
