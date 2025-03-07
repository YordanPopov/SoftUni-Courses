using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

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

            try
            {
                IWebElement boxElement = _driver.FindElement(By.Id("box0"));

                Assert.That(boxElement.Displayed, Is.True);
            }
            catch (NoSuchElementException ex)
            {
                Assert.Pass(ex.Message);
            }
        }

        [Test]
        public void RevealInputWithoutWaitsFails()
        {
            try
            {
				_driver.FindElement(By.Id("reveal")).Click();

				IWebElement revealedInput = _driver.FindElement(By.Id("revealed"));

				revealedInput.SendKeys("Displayed");
				Assert.That(revealedInput.GetAttribute("value"), Is.EqualTo("Displayed"));
			}
            catch (ElementNotInteractableException ex)
            {
                Assert.Pass(ex.Message);
            }           
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

        [Test]
        public void RevealInputWithExplicitWaits()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromMilliseconds(5000));

            _driver.FindElement(By.Id("reveal")).Click();

            IWebElement revealed = wait.Until(drv =>
            {
                var element = drv.FindElement(By.Id("revealed"));
                return element.Displayed ? element : null;
            });

            revealed.SendKeys("Displayed");
            Assert.That(revealed.GetAttribute("value"), Is.EqualTo("Displayed"));
        }

        [Test]
        public void AddBoxWithFluentWaitExpectedConditionsAndIgnoredExceptions()
        {
            _driver.FindElement(By.Id("adder")).Click();

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.PollingInterval = TimeSpan.FromMilliseconds(500);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));

            IWebElement newBox = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("box0")));
            Assert.That(newBox.Displayed, Is.True);
        }

        [Test]
        public void RevealInputWithCustomFluentWait()
        {
            IWebElement revealed = _driver.FindElement(By.Id("revealed"));
            _driver.FindElement(By.Id("reveal")).Click();

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5))
            {
                PollingInterval = TimeSpan.FromMilliseconds(500)
            };

            wait.IgnoreExceptionTypes(typeof(ElementNotInteractableException));
            wait.Until(drv =>
            {
                revealed.SendKeys("Displayed");
                return revealed;
            });

            Assert.That(revealed.TagName, Is.EqualTo("input"));
            Assert.That(revealed.GetAttribute("value"), Is.EqualTo("Displayed"));
        }

		[TearDown]
        public void TearDown()
        {
            _driver.Dispose();
        }
    }
}