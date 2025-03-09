using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace WorkingWithIFrames
{
	[TestFixture]
	public class IFrames
	{
		private IWebDriver _driver;

		[SetUp]
		public void Setup()
		{
			_driver = new ChromeDriver();
			_driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
			_driver.Navigate().GoToUrl("https://codepen.io/pervillalva/full/abPoNLd");
		}

		[TearDown]
		public void TearDown()
		{
			_driver.Quit();
			_driver.Dispose();
		}

		[Test]
		public void TestFrameByIndex()
		{
			WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));

			wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.TagName("iframe")));

			IWebElement dropDownBtn = wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("dropbtn")));
			dropDownBtn.Click();

			IReadOnlyCollection<IWebElement> dropDownLinks = wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.CssSelector(".dropdown-content a")));

			foreach (var link in dropDownLinks)
			{
				Console.WriteLine(link.Text);
				Assert.That(link.Displayed, Is.True);
			}

			_driver.SwitchTo().DefaultContent();
		}

		[Test]
		public void TestFrameById() {
			WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));

			wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt("result"));

			IWebElement dropDownBtn = wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("dropbtn")));
			dropDownBtn.Click();

			IReadOnlyCollection<IWebElement> dropDownLinks = wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.CssSelector(".dropdown-content a")));

			foreach (var link in dropDownLinks)
			{
				Console.WriteLine(link.Text);
				Assert.That(link.Displayed, Is.True);
			}

			_driver.SwitchTo().DefaultContent();
		}

		[Test]
		public void TestFrameByWebElement()
		{
			WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));

			IWebElement iFrame = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#result")));
			_driver.SwitchTo().Frame(iFrame);

			IWebElement dropDownBtn = wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("dropbtn")));
			dropDownBtn.Click();

			IReadOnlyCollection<IWebElement> dropDownLinks = wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.CssSelector(".dropdown-content a")));

			foreach (var link in dropDownLinks)
			{
				Console.WriteLine(link.Text);
				Assert.That(link.Displayed, Is.True);
			}

			_driver.SwitchTo().DefaultContent();
		}
	}
}