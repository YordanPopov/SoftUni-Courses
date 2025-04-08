using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeaCenterPOM.Pages
{
	public class LoginPage : BasePage
	{
		public LoginPage(IWebDriver driver) : base(driver) { }

		public override string PageUrl => base.PageUrl + "/Users/Login";

		public IWebElement EmailField => driver.FindElement(By.XPath("//input[@name='Email']"));

		public IWebElement PassField => driver.FindElement(By.XPath("//input[@name='Password']"));

		public IWebElement SignInButton => driver.FindElement(By.XPath("//button[@class='btn btn-primary btn-lg btn-block']"));
	}
}
