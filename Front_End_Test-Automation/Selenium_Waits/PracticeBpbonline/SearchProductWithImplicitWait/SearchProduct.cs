using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SearchProductWithImplicitWait
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
            _driver.Navigate().GoToUrl("https://practice.bpbonline.com/");
        }

        [Test]
        public void SearchProduct_Keyboard_ShouldAddToCart()
        {
            _driver.FindElement(By.Name("keywords")).SendKeys("keyboard");
            _driver.FindElement(By.XPath("//input[@title=' Quick Find ']")).Click();

            try
            {
                _driver.FindElement(By.XPath("//span[text()='Buy Now']")).Click();

                Assert.That(_driver.FindElement(By.TagName("h1")).Text, Is.EqualTo("What's In My Cart?"));
                Assert.That(_driver.PageSource.Contains("Microsoft Internet Keyboard PS/2"));
            }
            catch (Exception ex)
            {
                Assert.Fail("Unexpected exception: " + ex.Message);
            }
        }

        [Test]
        public void SearchProduct_Junk_ShouldThrowNoSuchElementException()
        {
            _driver.FindElement(By.Name("keywords")).SendKeys("Junk");
            _driver.FindElement(By.XPath("//input[@title=' Quick Find ']")).Click();

            //Assert.Throws<NoSuchElementException>(() => _driver.FindElement(By.XPath("//span[text()='Buy Now']")).Click());

            try
            {
                _driver.FindElement(By.XPath("//span[text()='Buy Now']")).Click();
			}
            catch (NoSuchElementException ex)
            {
                Assert.Pass("Expected NoSuchElementException was thrown!");
				Console.WriteLine("Exception: " + ex.Message);
            }
            catch (Exception ex)
            {
                Assert.Fail("Unexpected exception: " + ex.Message);
            }
        }

        [TearDown]
        public void TearDown() 
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}