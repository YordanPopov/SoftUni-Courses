using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace SaucedemoPOM.Pages
{
	public class BasePage
	{
		protected IWebDriver _driver;
		protected WebDriverWait _wait;

		public BasePage(IWebDriver driver)
		{
			this._driver = driver;
			_wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
		}

		protected IWebElement FindElement(By locator)
		{
			return _wait.Until(ExpectedConditions.ElementIsVisible(locator));
		}

		protected IReadOnlyCollection<IWebElement> FindElements(By locator)
		{
			return _driver.FindElements(locator);
		}

		protected void Click(By locator)
		{
			FindElement(locator).Click();
		}

		protected void Type(By locator, string text)
		{
			IWebElement el = FindElement(locator);
			el.Clear();
			el.SendKeys(text);
		}

		protected string GetText(By locator)
		{
			return FindElement(locator).Text;
		}


	}
}
