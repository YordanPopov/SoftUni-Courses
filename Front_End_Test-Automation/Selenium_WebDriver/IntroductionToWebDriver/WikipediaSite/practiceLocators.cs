using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V131.CSS;

namespace WikipediaSite;

public class practiceLocators
{
    IWebDriver _driver;
    private string baseUrl = "file:///C://Users//Yordan//Desktop//SimpleForm/Locators.html";

    [OneTimeSetUp]
    public void Setup()
    {
         _driver = new ChromeDriver();
         _driver.Navigate().GoToUrl(baseUrl);
    }

    [Test]
    public void Test_VerifyTheLocatedElements()
    {
        //Basic Locators
        var lastNameInputField = _driver.FindElement(By.Id("lname"));
        Assert.That(lastNameInputField.GetAttribute("value"), Is.EqualTo("Vega"));

        var newsletterCheckbox = _driver.FindElement(By.Name("newsletter"));
        Assert.That(newsletterCheckbox.Selected, Is.False);

        var softuniPageLink = _driver.FindElement(By.TagName("a"));
        Assert.That(softuniPageLink.Text, Is.EqualTo("Softuni Official Page"));

        var classInfoElements = _driver.FindElements(By.ClassName("information"));

		foreach (var element in classInfoElements)
		{
            Assert.That(element.GetCssValue("background-color"), Is.EqualTo("rgba(255, 255, 255, 1)"));
		}

        var linkFullText = _driver.FindElement(By.LinkText("Softuni Official Page"));
        Assert.That(linkFullText.GetAttribute("href"), Does.Contain("http://www.softuni.bg"));

        var linkPartialText = _driver.FindElement(By.PartialLinkText("Official Page"));
        Assert.That(linkPartialText.Displayed, Is.True);

        //CSS Selectors
        Assert.That(_driver.FindElement(By.CssSelector("#fname"))
            .GetAttribute("value")
            , Is.EqualTo("Vincent"));

        Assert.That(_driver.FindElement(By.CssSelector("[name='fname']"))
            .GetAttribute("value")
            , Is.EqualTo("Vincent"));

        Assert.That(_driver.FindElement(By.CssSelector(".button"))
            .GetAttribute("value")
            , Is.EqualTo("Submit"));

        Assert.That(_driver.FindElement(By.CssSelector("div.additional-info > p > input[type='text']"))
            .Displayed, Is.True);

        //Xpath Locators
        Assert.That(_driver.FindElement(By.XPath("(/html/body/form/input[@name='gender'])[1]"))
            .GetAttribute("value")
            , Is.EqualTo("m"));

		Assert.That(_driver.FindElement(By.XPath("//input[@name='gender'][last()]"))
			.GetAttribute("value")
			, Is.EqualTo("f"));

        Assert.That(_driver.FindElement(By.XPath("//input[@id='lname']"))
            .GetAttribute("value")
            , Is.EqualTo("Vega"));

        Assert.That(_driver.FindElement(By.XPath("//input[@name='newsletter']"))
            .GetAttribute("type")
            , Is.EqualTo("checkbox"));

        Assert.That(_driver.FindElement(By.XPath("//input[@class='button']"))
            .GetAttribute("value")
            , Is.EqualTo("Submit"));

        Assert.That(_driver.FindElement(By.XPath("//div/p/input"))
            .Displayed, Is.True);
	}

    [Test]
    public void Test_Verify_ThankYou_Message_IsDisplayed()
    {
        Assert.That(_driver.PageSource, Does.Contain("Contact Form"));

        _driver.FindElement(By.XPath("//input[@value='m']")).Click();

        var fname = _driver.FindElement(By.XPath("//input[@id='fname']"));
        fname.Clear();
        fname.SendKeys("Butch");

		var lname = _driver.FindElement(By.XPath("//input[@id='lname']"));
		lname.Clear();
		lname.SendKeys("Coolidge");

        Assert.That(_driver.FindElement(By.XPath("//div[@class='additional-info']")).Displayed, Is.True);

        _driver.FindElement(By.XPath("//div/p/input")).SendKeys("0888999777");

        var newsletterCheckbox = _driver.FindElement(By.XPath("//input[@name='newsletter']"));
        newsletterCheckbox.Click();
        Assert.That(newsletterCheckbox.Selected, Is.True);

        _driver.FindElement(By.XPath("//input[@class='button']")).Click();

        Assert.That(_driver.Url, Does.Contain("thankyou.html"));
        Assert.That(_driver.PageSource, Does.Contain("Thank You!"));
	}

    [OneTimeTearDown]
    public void TearDown() { 
        _driver.Quit();
        _driver.Dispose();
    }
}
