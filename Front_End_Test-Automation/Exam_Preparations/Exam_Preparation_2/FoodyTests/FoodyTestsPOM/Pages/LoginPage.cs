using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodyTestsPOM.Pages
{
	public class LoginPage : BasePage
	{
		public LoginPage(IWebDriver drv) : base(drv) { }

		public override string PageUrl => base.PageUrl + "/User/Login";

		public IWebElement UserNameField => driver.FindElement(By.Name("Username"));

		public IWebElement PasswordField => driver.FindElement(By.Name("Password"));

		public IWebElement LogInButton => driver.FindElement(By.XPath("//button[@type='submit']"));

		public void PerformLogin(string userName, string pass)
		{
			UserNameField.Clear();
			UserNameField.SendKeys(userName);

			PasswordField.Clear();
			PasswordField.SendKeys(pass);

			LogInButton.Click();
		}
	}
}
