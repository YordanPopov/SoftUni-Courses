using StudentRegistryPOM.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistryPOM.PagesTests
{
	public class AddStudentsPageTests : BaseTest
	{
		[Test]
		public void Test_AddStudentPage_Content()
		{
			_addStudentPage.Open();

			Assert.That(_addStudentPage.GetPageTitle(), Is.EqualTo("Add Student"));
			Assert.That(_addStudentPage.GetPageHeadingText(), Is.EqualTo("Register New Student"));
			Assert.That(_addStudentPage.FieldStudentName.Text, Is.Empty);
			Assert.That(_addStudentPage.FieldStudentEmail.Text, Is.EqualTo(""));
			Assert.That(_addStudentPage.AddButton.Text, Is.EqualTo("Add"));
		}

		[Test]
		public void Test_AddStudentPage_Links()
		{
			_addStudentPage.Open();

			_addStudentPage.LinkHomePage.Click();
			Assert.That(new HomePage(_driver).IsOpen(), Is.True);

			_addStudentPage.Open();
			_addStudentPage.LinkViewStudentsPage.Click();
			Assert.That(new ViewStudentsPage(_driver).IsOpen(), Is.True);

			_addStudentPage.Open();
			_addStudentPage.LinkAddStudentPage.Click();
			Assert.That(new AddStudentPage(_driver).IsOpen(), Is.True);
		}

		[Test]
		public void Test_AddStudentPage_AddValidStudent()
		{
			_addStudentPage.Open();

			var rnd = new Random()
				.Next(1000, 9999);

			string userName = "testName_" + rnd;
			string userEmail = "testUser_" + rnd + "@email.com";

			_addStudentPage.AddStudent(userName, userEmail);

			var viewStudentsPage = new ViewStudentsPage(_driver);
			Assert.That(viewStudentsPage.IsOpen(), Is.True);

			string[] studentsList = viewStudentsPage.GetStudentsList();
			Assert.That(studentsList, Does.Contain($"{userName} ({userEmail})"));
		}

		[Test]
		public void Test_AddStudentPage_AddInvalidStudent()
		{
			_addStudentPage.Open();

			_addStudentPage.AddStudent("", "");
			Assert.That(new AddStudentPage(_driver).IsOpen(), Is.True);
			Assert.That(_addStudentPage.GetErrorMsg(), Is.EqualTo("Cannot add student. Name and email fields are required!"));
		}
	}
}
