using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelenoidTestProject
{
	[TestFixture("chrome", "128.0")]
	[TestFixture("firefox", "125.0")]
	public class SelenoidTests
	{
		private IWebDriver driver;
		private string browserName;
		private string browserVersion;

		public SelenoidTests(string name, string version)
		{
			this.browserName = name;
			this.browserVersion = version;
		}

		[SetUp]
		public void SetUp()
		{
			var options = GetOptions(this.browserName, this.browserVersion);

			this.driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), options);
			this.driver.Url = "https://www.wikipedia.org/";

			this.driver.Manage().Window.Maximize();
			this.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
		}

		[Test]
		public void CheckThatArticleTitleIsAsExpected()
		{
			driver.FindElement(By.Id("searchInput")).SendKeys("Quality Assurance");
			driver.FindElement(By.XPath("//button[@type='submit']")).Click();

			string expectedTitle = driver.FindElement(By.Id("firstHeading")).Text;
			Assert.That(expectedTitle, Is.EqualTo("Quality assurance"));
		}

		[Test]
		public void CheckThatWelcomeMessageIsAsExpected()
		{
			driver.FindElement(By.Id("searchInput")).SendKeys("Quality Assurance");
			driver.FindElement(By.XPath("//button[@type='submit']")).Click();

			driver.FindElement(By.XPath("//a[@class='mw-logo']")).Click();

			string expectedWelcomeMsg = driver.FindElement(By.Id("Welcome_to_Wikipedia")).Text;
			Assert.That(expectedWelcomeMsg, Is.EqualTo("Welcome to Wikipedia"));
		}

		[TearDown]
		public void TearDown()
		{
			this.driver?.Close();
		}

		private DriverOptions GetOptions(string browserName, string browserVersion)
		{
			if (browserName == "chrome")
			{
				ChromeOptions options = new ChromeOptions();
				options.BrowserVersion = browserVersion;

				options.AddAdditionalOption("selenoid:options", new Dictionary<string, object>
				{
					["name"] = "Chrome browser tests...",
					["sessionTimeout"] = "10m",
					["labels"] = new Dictionary<string, object>
					{
						["manual"] = "false"
					},
					["enableVideo"] = true,
					["enableVNC"] = true
				});

				return options;
			}
			else
			{
				FirefoxOptions options = new FirefoxOptions();
				options.BrowserVersion = browserVersion;

				options.AddAdditionalOption("selenoid:options", new Dictionary<string, object>
				{
					["name"] = "Firefox browser tests...",
					["sessionTimeout"] = "10m",
					["labels"] = new Dictionary<string, object>
					{
						["manual"] = "false"
					},
					["enableVideo"] = false,
					["enableVNC"] = true
				});

				return options;
			}
		}
	}
}
