using e2eTests.Data;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace e2eTests;

[TestFixture]
public class CRUD
{
    private IWebDriver driver;
    private WebDriverWait wait;
    private IAlert alert;
    
    string baseUrl = "http://localhost:3000";
    Album testAlbum;

	[SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
        driver.Navigate().GoToUrl(baseUrl);
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
        wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(1000));

        //Login
        driver.FindElement(By.LinkText("Login")).Click();
        driver.FindElement(By.Id("email")).SendKeys(TestContext.RegisteredUser.UserEmail);
        driver.FindElement(By.Id("password")).SendKeys(TestContext.RegisteredUser.Password);
        driver.FindElement(By.ClassName("login")).Click();
        Assert.That(driver.FindElement(By.LinkText("Logout")).Displayed, Is.True);     
    }

    [TearDown]
    public void TearDown()
    {
        driver.Quit();
        driver.Dispose();
    }

    [Test, Order(1)]
    public void UserCanCreateAlbumWithValidData()
    {
        driver.FindElement(By.LinkText("Create Album")).Click();
        Assert.That(driver.Url, Does.Contain("/create"));
        Assert.That(driver.FindElement(By.TagName("form")).Displayed, Is.True);

        string name = "testAlbum" + new Random().Next(1000, 9999);
		testAlbum = new Album(name);
        driver.FindElement(By.Id("name")).SendKeys(testAlbum.Name);
        driver.FindElement(By.Id("imgUrl")).SendKeys(testAlbum.ImageUrl);
        driver.FindElement(By.Id("price")).SendKeys(testAlbum.Price);
        driver.FindElement(By.Id("releaseDate")).SendKeys(testAlbum.ReleaseDate);
        driver.FindElement(By.Id("artist")).SendKeys(testAlbum.Artist);
        driver.FindElement(By.Id("genre")).SendKeys(testAlbum.Genre);
        driver.FindElement(By.Name("description")).SendKeys(testAlbum.Description);

        IWebElement addBtn = driver.FindElement(By.ClassName("add-album"));
        IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
        js.ExecuteScript("arguments[0].click();", addBtn);

		IReadOnlyCollection<IWebElement> albumsNames = driver.FindElements(By.CssSelector("p.name"));

		foreach (var albumName in albumsNames)
		{
			if (albumName.Text == $"Name: {testAlbum.Name}")
			{
                Assert.Pass("Album is successfully created");
			}
		}

        Assert.Fail("Album was not created");
	}

    [Test, Order(3)]
    public void UserCanEditAlbumWithValidData()
    {
		driver.FindElement(By.LinkText("Search")).Click();
		driver.FindElement(By.Id("search-input")).SendKeys(testAlbum.Name);
		driver.FindElement(By.ClassName("button-list")).Click();

		IWebElement detailsBtn = driver.FindElement(By.Id("details"));
		IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
		js.ExecuteScript("arguments[0].click();", detailsBtn);

        driver.FindElement(By.CssSelector("a.edit")).Click();
		Assert.That(driver.FindElement(By.TagName("form")).Displayed, Is.True);

        testAlbum.Name += "_Edited";
        IWebElement nameField = driver.FindElement(By.Id("name"));
        nameField.Clear();
        nameField.SendKeys(testAlbum.Name);

        IWebElement editBtn = driver.FindElement(By.ClassName("edit-album"));
        js.ExecuteScript("arguments[0].click();", editBtn);

        Assert.That(driver.FindElement(By.TagName("h1")).Text, Does.Contain(testAlbum.Name));
	}

	[Test, Order(2)]
	public void UserCannotEditAlbumWithEmptyNameField()
	{
		driver.FindElement(By.LinkText("Search")).Click();
		driver.FindElement(By.Id("search-input")).SendKeys(testAlbum.Name);
		driver.FindElement(By.ClassName("button-list")).Click();

		IWebElement detailsBtn = driver.FindElement(By.Id("details"));
		IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
		js.ExecuteScript("arguments[0].click();", detailsBtn);

		driver.FindElement(By.CssSelector("a.edit")).Click();
		Assert.That(driver.FindElement(By.TagName("form")).Displayed, Is.True);
        
        driver.FindElement(By.Id("name")).Clear();

		IWebElement editBtn = driver.FindElement(By.ClassName("edit-album"));
		js.ExecuteScript("arguments[0].click();", editBtn);

        alert = driver.SwitchTo().Alert();
        Assert.That(alert.Text, Is.EqualTo("No empty fields are allowed!"));
        alert.Accept();

        Assert.That(driver.Url, Does.Contain("/edit"));
	}

	[Test, Order(4)]
    public void UserCanDeleteAlbum()
    {
        driver.FindElement(By.LinkText("Search")).Click();
        driver.FindElement(By.Id("search-input")).SendKeys(testAlbum.Name);
        driver.FindElement(By.ClassName("button-list")).Click();

        IWebElement detailsBtn = driver.FindElement(By.Id("details"));
        IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
        js.ExecuteScript("arguments[0].click();", detailsBtn);

        driver.FindElement(By.CssSelector("a.remove")).Click();

        Assert.That(driver.PageSource, Does.Not.Contain(testAlbum.Name));
    }
}
