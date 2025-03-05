using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumWaitsLab
{
    public class DemoWaits
    {
        private IWebDriver _driver;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl("https://www.selenium.dev/selenium/web/dynamic.html ");
        }

        [Test]
        public void AddBoxWithoutWaitsFails()
        {
            _driver.FindElement(By.Id("adder")).Click();

            IWebElement boxElement = _driver.FindElement(By.Id("box0"));

            Assert.That(boxElement.Displayed, Is.True);

        }

        [Test]
        public void RevealInputWithoutWaitsFails()
        {
            _driver.FindElement(By.Id("reveal")).Click();

            IWebElement revealedInput = _driver.FindElement(By.Id("revealed"));

            revealedInput.SendKeys("Displayed");
            Assert.That(revealedInput.GetAttribute("value"), Is.EqualTo("Displayed"));
        }

        [Test]
        public void AddBoxWithThreadSleep()
        {
            _driver.FindElement(By.Id("adder")).Click();

            Thread.Sleep(3000);

            IWebElement newBox = _driver.FindElement(By.Id("box0"));

            Assert.That(newBox.Displayed, Is.True); 
        }

		[Test]
		public void AddBoxWithImplicitWait()
		{
			_driver.FindElement(By.Id("adder")).Click();

			_driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

			IWebElement newBox = _driver.FindElement(By.Id("box0"));

			Assert.That(newBox.Displayed, Is.True);
		}

		[Test]
		public void RevealInputWithImplicitWait()
		{
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

			_driver.FindElement(By.Id("reveal")).Click();

			IWebElement revealedInput = _driver.FindElement(By.Id("revealed"));

			revealedInput.SendKeys("Displayed");
			Assert.That(revealedInput.GetAttribute("value"), Is.EqualTo("Displayed"));
            Assert.That(revealedInput.TagName, Is.EqualTo("input"));
		}

		[TearDown]
        public void TearDown()
        {
            _driver.Dispose();
        }
    }
}