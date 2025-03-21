using OpenQA.Selenium;
using StudentRegistryPOM.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistryPOM.PagesTests
{
	public class ViewStudentsPageTests : BaseTest
	{
		[Test]
		public void Test_ViewStudentsPage_Content()
		{
			_viewStudentPage.Open();

			Assert.That(_viewStudentPage.GetPageTitle(), Is.EqualTo("Students"));
			Assert.That(_viewStudentPage.GetPageHeadingText(), Is.EqualTo("Registered Students"));

			string[] studentsList = _viewStudentPage.GetStudentsList();

			foreach (var student in studentsList)
			{
				Assert.That(student.IndexOf("(") > 0, Is.True);
				Assert.That(student.LastIndexOf(")") == student.Length - 1, Is.True);
			}
		}

		[Test]
		public void Test_ViewStudentsPage_Links()
		{
			_viewStudentPage.Open();

			_viewStudentPage.LinkViewStudentsPage.Click();
			Assert.That(new ViewStudentsPage(_driver).IsOpen, Is.True);

			_viewStudentPage.Open();
			_viewStudentPage.LinkHomePage.Click();
			Assert.That(new HomePage(_driver).IsOpen, Is.True);

			_viewStudentPage.Open();
			_viewStudentPage.LinkAddStudentPage.Click();
			Assert.That(new AddStudentPage(_driver).IsOpen, Is.True);
		}
	}
}
