using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SumTwoNumbers
{
	public class Tests
	{
		private IWebDriver _driver;
		SumNumberPage sumPage;

		[SetUp]
		public void Setup()
		{
			_driver = new ChromeDriver();
			sumPage = new SumNumberPage(_driver);

			sumPage.OpenPage();
		}

		[TearDown]
		public void TearDown()
		{
			_driver.Quit();
			_driver.Dispose();
		}

		[Test]
		public void TestSumValidNumbers()
		{
			Assert.That(sumPage.AddNumbers("10", "10"), Is.EqualTo("Sum: 20"));
		}

		[Test]
		public void TestSumInvalidInputs()
		{
			Assert.That(sumPage.AddNumbers("InvalidInput1", "InvalidInput2"), Is.EqualTo("Sum: invalid input"));
		}
	}
}