using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WikipediaSite
{
    public class OpenWikipediaSite
    {
        IWebDriver _driver;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();

            _driver.Navigate().GoToUrl("https://www.wikipedia.org/");
        }

        [Test]
        public void Verify_Page_Title()
        {
            //Console.WriteLine("Main page title: " + _driver.Title);
            Assert.That(_driver.Title, Is.EqualTo("Wikipedia"));

            var searchBox = _driver.FindElement(By.Id("searchInput"));
            searchBox.Click();
            searchBox.SendKeys("Quality assurance" + Keys.Enter);

            //Console.WriteLine("Quality assurance page title: " + _driver.Title);
            Assert.That(_driver.Title, Is.EqualTo("Quality assurance - Wikipedia"));
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}