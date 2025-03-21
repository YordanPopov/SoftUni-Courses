using StudentRegistryPOM.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistryPOM.PagesTests
{
	public class HomePageTests : BaseTest
	{
		[Test]
		public void Test_HomePage_Content()
		{
			_homePage.Open();

			Assert.That(_homePage.GetPageTitle(), Is.EqualTo("MVC Example"));
			Assert.That(_homePage.GetPageHeadingText(), Is.EqualTo("Students Registry"));
			Assert.That(_homePage.GetStudentCount(), Is.GreaterThan(0));
		}

		[Test]
		public void Test_HomePage_Links()
		{
			_homePage.Open();

			_homePage.LinkHomePage.Click();
			Assert.That(new HomePage(_driver).IsOpen(), Is.True);

			_homePage.Open();
			_homePage.LinkAddStudentPage.Click();
			Assert.That(new AddStudentPage(_driver).IsOpen(), Is.True);

			_homePage.Open();
			_homePage.LinkViewStudentsPage.Click();
			Assert.That(new ViewStudentsPage(_driver).IsOpen(), Is.True);
		}
	}
}
