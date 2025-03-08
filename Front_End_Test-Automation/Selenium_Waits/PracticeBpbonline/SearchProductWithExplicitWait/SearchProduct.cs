using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SearchProductWithExplicitWait
{
	[TestFixture]
	public class SearchProduct
	{
		private IWebDriver _driver;
		[SetUp]
		public void Setup()
		{
			_driver = new ChromeDriver();
			_driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
			_driver.Navigate().GoToUrl("http://practice.bpbonline.com/");
		}

		[TearDown]
		public void Teardown()
		{
			_driver.Quit();
			_driver.Dispose();
		}

		[Test]
		public void SearchProduct_Keyboard_ShouldAddToCart()
		{
			_driver.FindElement(By.Name("keywords")).SendKeys("keyboard");
			_driver.FindElement(By.XPath("//input[@title=' Quick Find ']")).Click();

			_driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);

			try
			{
				WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));

				IWebElement buyNowBtn = wait.Until(drv => drv.FindElement(By.XPath("//span[text()='Buy Now']")));

				_driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

				buyNowBtn.Click();

				Assert.That(_driver.FindElement(By.TagName("h1")).Text, Is.EqualTo("What's In My Cart?"));
				Assert.That(_driver.PageSource, Does.Contain("Microsoft Internet Keyboard PS/2"));
			}
			catch (Exception ex)
			{
				Assert.Fail("Unexpected exception: " + ex.Message);
			}
		}

		[Test]
		public void SearchProduct_Junk_ShouldThrowWebDriverTimeoutException()
		{
			_driver.FindElement(By.Name("keywords")).SendKeys("Junk");
			_driver.FindElement(By.XPath("//input[@title=' Quick Find ']")).Click();

			_driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);

			try
			{
				WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));

				IWebElement buyNowBtn = wait.Until(drv => drv.FindElement(By.XPath("//span[text()='Buy Now']")));
				buyNowBtn.Click();

				Assert.Fail("The [Buy Now] button was found for a non-existing product");
			}
			catch (WebDriverTimeoutException ex)
			{
				Assert.Pass("Expected WebDriverTimeoutException was thrown");
				Console.WriteLine("Expected exception:" + ex.Message);
			}
			catch (Exception ex)
			{
				Assert.Fail("Unexpected exception: " + ex.Message);
			}
			finally
			{
				_driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
			}
		}
	}
}