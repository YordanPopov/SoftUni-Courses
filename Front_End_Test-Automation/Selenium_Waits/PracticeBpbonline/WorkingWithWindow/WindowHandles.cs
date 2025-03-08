using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.ObjectModel;

namespace WorkingWithWindow
{
	[TestFixture]
	public class WindowHandles
	{
		private IWebDriver _driver;

		[SetUp]
		public void Setup()
		{
			_driver = new ChromeDriver();
			_driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
			_driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/windows");
		}

		[TearDown]
		public void Teardown() 
		{
			_driver.Quit();
			_driver.Dispose();
		}

		[Test]
		public void HandleMultipleWindows()
		{
			_driver.FindElement(By.XPath("//a[text()='Click Here']")).Click();

			ReadOnlyCollection<string> windowHandles = _driver.WindowHandles;
			Assert.That(windowHandles.Count, Is.GreaterThanOrEqualTo(2));

			_driver.SwitchTo().Window(windowHandles[1]);
			Assert.That(_driver.PageSource, Does.Contain("New Window"));

			_driver.Close();
			_driver.SwitchTo().Window(windowHandles[0]);
			Assert.That(_driver.PageSource, Does.Contain("Opening a new window"));
		}

		[Test]
		public void HandleNoSuchWindowException()
		{
			_driver.FindElement(By.LinkText("Click Here")).Click();

			ReadOnlyCollection<string> windowHandles = _driver.WindowHandles;

			_driver.SwitchTo().Window(windowHandles[1]);
			_driver.Close();

			try
			{
				_driver.SwitchTo().Window(windowHandles[1]);
			}
			catch (NoSuchWindowException ex)
			{
				Assert.Pass("NoSuchWindowException was thrown: " + ex.Message);
			}
			catch (Exception ex)
			{
				Assert.Fail("An unexpected exception: " + ex.Message);
			}
			finally
			{
				_driver.SwitchTo().Window(windowHandles[0]);
			}
		}
	}
}