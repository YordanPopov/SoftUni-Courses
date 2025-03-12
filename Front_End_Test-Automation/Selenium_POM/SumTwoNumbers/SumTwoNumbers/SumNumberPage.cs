using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumTwoNumbers
{
	public class SumNumberPage
	{
		private readonly IWebDriver _driver;

		public SumNumberPage(IWebDriver driver)
		{
			_driver = driver;

			driver.Manage().Timeouts()
				.ImplicitWait = TimeSpan.FromSeconds(5);
		}

		const string PageUrl = "http://localhost:8080/sum-num.html";

		public IWebElement firstNumField => _driver.FindElement(By.Id("number1"));
		public IWebElement secondNumField => _driver.FindElement(By.Id("number2"));
		public IWebElement calcBtn => _driver.FindElement(By.Id("calcButton"));
		public IWebElement resetBtn => _driver.FindElement(By.Id("resetButton"));
		public IWebElement resultElement => _driver.FindElement(By.Id("result"));

		public void OpenPage()
		{
			_driver.Navigate().GoToUrl(PageUrl);
		}

		public string AddNumbers(string num1, string num2)
		{
			firstNumField.SendKeys(num1);
			secondNumField.SendKeys(num2);
			calcBtn.Click();

			string result = resultElement.Text;
			return result;
		}

		public void ResetForm()
		{
			resetBtn.Click();
		}

		public bool IsFormEmpty()
		{
			return firstNumField.Text + secondNumField.Text + resultElement.Text == "";
		}
	}
}
