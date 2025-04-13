using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamTests.Pages
{
	public class HomePage : BasePage
	{
		public HomePage(IWebDriver driver) : base(driver)
		{

		}

		public override string PageUrl => base.PageUrl + "/";
	}
}
