using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Xml.XPath;

namespace WorkingWithAlerts
{
	[TestFixture]
	public class Alerts
	{
		private IWebDriver _driver;

		[SetUp]
		public void Setup()
		{
			_driver = new ChromeDriver();
			_driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
			_driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/javascript_alerts");
		}

		[TearDown]
		public void Teardown()
		{
			_driver.Quit();
			_driver.Dispose();
		}

		[Test]
		public void HandleBasicAlert()
		{
			_driver.FindElement(By.XPath("//button[@onclick='jsAlert()']")).Click();

			IAlert alert = _driver.SwitchTo().Alert();
			Assert.That(alert.Text, Is.EqualTo("I am a JS Alert"));

			alert.Accept();
			IWebElement result = _driver.FindElement(By.Id("result"));
			Assert.That(result.TagName, Is.EqualTo("p"));
			Assert.That(result.Text, Is.EqualTo("You successfully clicked an alert"));
		}

		[Test]
		public void HandleConfirmAlert()
		{
			_driver.FindElement(By.XPath("//button[@onclick='jsConfirm()']")).Click();

			IAlert confirmAlert = _driver.SwitchTo().Alert();
			Assert.That(confirmAlert.Text, Is.EqualTo("I am a JS Confirm"));

			confirmAlert.Accept();

			IWebElement result = _driver.FindElement(By.Id("result"));
			Assert.That(result.TagName, Is.EqualTo("p"));
			Assert.That(result.Text, Is.EqualTo("You clicked: Ok"));

			_driver.FindElement(By.XPath("//button[@onclick='jsConfirm()']")).Click();
			confirmAlert = _driver.SwitchTo().Alert();
			confirmAlert.Dismiss();

			result = _driver.FindElement(By.Id("result"));
			Assert.That(result.Text, Is.EqualTo("You clicked: Cancel"));
		}

		[Test]
		public void HandlePromptAlert()
		{
			_driver.FindElement(By.XPath("//button[@onclick='jsPrompt()']")).Click();

			IAlert promptAlert = _driver.SwitchTo().Alert();
			Assert.That(promptAlert.Text, Is.EqualTo("I am a JS prompt"));

			promptAlert.SendKeys("Hello");
			promptAlert.Accept();

			IWebElement resultElement = _driver.FindElement(By.Id("result"));
			Assert.That(resultElement.Text, Is.EqualTo("You entered: Hello"));

			_driver.FindElement(By.XPath("//button[@onclick='jsPrompt()']")).Click();
			promptAlert = _driver.SwitchTo().Alert();
			promptAlert.Dismiss();

			resultElement = _driver.FindElement(By.Id("result"));
			Assert.That(resultElement.Text, Is.EqualTo("You entered: nul l"));
		}
	}
}