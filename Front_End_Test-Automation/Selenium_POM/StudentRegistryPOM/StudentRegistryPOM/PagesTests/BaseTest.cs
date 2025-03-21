using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using StudentRegistryPOM.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistryPOM.PagesTests
{
	public class BaseTest
	{
		protected IWebDriver _driver;
		protected HomePage _homePage;
		protected AddStudentPage _addStudentPage;
		protected ViewStudentsPage _viewStudentPage;

		[OneTimeSetUp]
		public void BaseSetUp()
		{
			_driver = new ChromeDriver();
			_homePage = new HomePage(_driver);
			_addStudentPage = new AddStudentPage(_driver);
			_viewStudentPage = new ViewStudentsPage(_driver);
		}

		[OneTimeTearDown]
		public void BaseTearDown()
		{
			_driver.Quit();
			_driver.Dispose();
		}
	}
}
