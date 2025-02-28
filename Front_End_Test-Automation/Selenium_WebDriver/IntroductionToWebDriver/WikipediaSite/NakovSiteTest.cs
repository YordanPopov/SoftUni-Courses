using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WikipediaSite;

public class NakovSiteTest
{
    IWebDriver _driver;

    [SetUp]
    public void Setup()
    {
        _driver = new ChromeDriver();
        _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(500);
        _driver.Navigate().GoToUrl("https://nakov.com/");
    }

    [Test]
    public void Test_NakovCom()
    {
        var pageTitle = _driver.Title;
        Assert.That(pageTitle.Contains("Svetlin Nakov - Svetlin Nakov – Official Web Site and Blog"));

        var searchLink = _driver.FindElement(By.ClassName("smoothScroll"));
        Assert.That(searchLink.Text, Does.Contain("SEARCH"));

        searchLink.Click();

        var message = _driver.FindElement(By.Id("s"));
        var placeHolder = message.GetAttribute("placeholder");
        Assert.That(placeHolder, Is.EqualTo("Search this site "));
    }

    [TearDown]
    public void Teardown()
    {
        _driver.Quit();
        _driver.Dispose(); 
    }
}
