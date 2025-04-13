using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamTests.Pages
{
	public class LoginPage : BasePage
	{
		public LoginPage(IWebDriver driver) : base(driver)
		{

		}

		public override string PageUrl => base.PageUrl + "/User/Login";

		public IWebElement EmailField => _driver.FindElement(By.XPath("//input[@name='Email']"));

		public IWebElement PasswordField => _driver.FindElement(By.XPath("//input[@name='Password']"));

		public IWebElement LoginButton => _driver.FindElement(By.XPath("//button[@type='submit']"));

		public void LoginUser(string email, string password)
		{
			EmailField.Clear();
			EmailField.SendKeys(email);

			PasswordField.Clear();
			PasswordField.SendKeys(password);

			LoginButton.Click();	
		}
	}
}
