using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace NumberCalculator
{
    [TestFixture]
    public class TestCalculator
    {
        IWebDriver driver;
        IWebElement textBoxFirstNum;
        IWebElement textBoxSecondNum;
        IWebElement dropDownOperation;
        IWebElement calcBtn;
        IWebElement resetBtn;
        IWebElement divResult;

        [OneTimeSetUp]
        public void Setup()
        {
            var options = new ChromeOptions();
            options.AddArgument("--headless=new");
            driver = new ChromeDriver(options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Navigate().GoToUrl("http://localhost:8080/number-calculator.html");
            

            textBoxFirstNum = driver.FindElement(By.Id("number1"));
            textBoxSecondNum = driver.FindElement(By.Id("number2"));
            dropDownOperation = driver.FindElement(By.Id("operation"));
			calcBtn = driver.FindElement(By.Id("calcButton"));
            resetBtn = driver.FindElement(By.Id("resetButton"));
            divResult = driver.FindElement(By.Id("result"));


        }

        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }

        public void PerformCalculation(string firstNumber, string operation, string secondNumber, string expectedResult)
        {
            resetBtn.Click();

			if (!string.IsNullOrEmpty(firstNumber))
			{
                textBoxFirstNum.SendKeys(firstNumber);
			}

			if (!string.IsNullOrEmpty(secondNumber))
			{
				textBoxSecondNum.SendKeys(secondNumber);
			}

			if (!string.IsNullOrEmpty(operation))
			{
				new SelectElement(dropDownOperation).SelectByText(operation);
			}

            calcBtn.Click();

            Assert.That(divResult.Text, Is.EqualTo($"Result: {expectedResult}"));
		}

        [Test]
        [TestCase("1", "+ (sum)", "1", "2")]
		[TestCase("-10", "+ (sum)", "-10", "-20")]
		[TestCase("1", "+ (sum)", "-1", "0")]
		[TestCase("invalid", "+ (sum)", "1", "invalid input")]
		[TestCase("1", "+ (sum)", "invalid", "invalid input")]
		[TestCase("1", "- (subtract)", "1", "0")]
		[TestCase("1", "- (subtract)", "-1", "2")]
		[TestCase("-1", "- (subtract)", "1", "-2")]
		[TestCase("invalid", "- (subtract)", "1", "invalid input")]
		[TestCase("1", "- (subtract)", "invalid", "invalid input")]
		[TestCase("1.3", "- (subtract)", "1.2", "0.1")]
		[TestCase("5", "* (multiply)", "2", "10")]
		[TestCase("10", "/ (divide)", "2", "5")]
		public void Test_Number_Calculator(string firstNumber, string operation, string secondNumber, string expectedResult)
        {
            PerformCalculation(firstNumber, operation, secondNumber, expectedResult);
        }
    }
}