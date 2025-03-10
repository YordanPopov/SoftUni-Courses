using e2eTests.Data;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace e2eTests;

[TestFixture]
public class AuthenticationTests
{
	private IWebDriver driver;
	private WebDriverWait wait;
	private IAlert alert;

	public string baseUrl = "http://localhost:3000";
	public User testUser;
	[SetUp]
	public void Setup()
	{
		var options = new ChromeOptions();
		options.AddArgument("--headless");
		driver = new ChromeDriver(options);
		driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
		driver.Navigate().GoToUrl(baseUrl);

		wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(1000));
	}

	[TearDown]
	public void TearDown()
	{
		driver.Quit();
		driver.Dispose();
	}

	[Test, Order(1)]
	public void UserCanRegisterWithValidData()
	{
		IWebElement registerLink = wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("Register")));
		registerLink.Click();

		Assert.That(driver.Url, Is.EqualTo(baseUrl + "/register"));
		Assert.That(driver.FindElement(By.TagName("form")).Displayed, Is.True);

		string email = $"testUser{new Random().Next(1000, 9999)}@email.com";
		testUser = new User(email, "123456");

		driver.FindElement(By.Id("email")).SendKeys(testUser.UserEmail);
		driver.FindElement(By.Id("password")).SendKeys(testUser.Password);
		driver.FindElement(By.Id("conf-pass")).SendKeys(testUser.ConfirmPassword);
		driver.FindElement(By.ClassName("register")).Click();

		Assert.That(driver.Url, Is.EqualTo(baseUrl + "/"));
		Assert.That(driver.FindElement(By.LinkText("Create Album"))
			.Displayed, Is.True);
		Assert.That(driver.FindElement(By.LinkText("Logout"))
			.Displayed, Is.True);

		TestContext.RegisteredUser = testUser;
	}

	[Test, Order(2)]
	public void UserCanLoginWithValidData()
	{
		IWebElement loginLink = wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("Login")));
		loginLink.Click();

		Assert.That(driver.Url, Is.EqualTo(baseUrl + "/login"));
		Assert.That(driver.FindElement(By.TagName("form")).Displayed, Is.True);

		driver.FindElement(By.Id("email")).SendKeys(testUser.UserEmail);
		driver.FindElement(By.Id("password")).SendKeys(testUser.Password);
		driver.FindElement(By.ClassName("login")).Click();

		Assert.That(driver.Url, Is.EqualTo(baseUrl + "/"));
		Assert.That(driver.FindElement(By.LinkText("Create Album"))
			.Displayed, Is.True);
		Assert.That(driver.FindElement(By.LinkText("Logout"))
			.Displayed, Is.True);
	}

	[Test, Order(3)]
	public void CannotRegisterExistingUser()
	{
		IWebElement registerLink = wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("Register")));
		registerLink.Click();

		Assert.That(driver.Url, Is.EqualTo(baseUrl + "/register"));
		Assert.That(driver.FindElement(By.TagName("form")).Displayed, Is.True);

		driver.FindElement(By.Id("email")).SendKeys(testUser.UserEmail);
		driver.FindElement(By.Id("password")).SendKeys(testUser.Password);
		driver.FindElement(By.Id("conf-pass")).SendKeys(testUser.ConfirmPassword);
		driver.FindElement(By.ClassName("register")).Click();

		alert = driver.SwitchTo().Alert();
		Assert.That(alert.Text, Is.EqualTo("Already existing email!"));
		alert.Accept();

		Assert.That(driver.Url, Is.EqualTo(baseUrl + "/register"));
	}

	[Test, Order(4)]
	public void RegisterWithEmptyFieldsShouldFail()
	{
		IWebElement registerLink = wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("Register")));
		registerLink.Click();

		Assert.That(driver.Url, Is.EqualTo(baseUrl + "/register"));
		Assert.That(driver.FindElement(By.TagName("form")).Displayed, Is.True);

		driver.FindElement(By.ClassName("register")).Click();

		alert = driver.SwitchTo().Alert();
		Assert.That(alert.Text, Is.EqualTo("No empty fields are allowed! Confirm password need to match given password!"));
		alert.Accept();

		Assert.That(driver.Url, Is.EqualTo(baseUrl + "/register"));
	}

	[Test, Order(5)]
	public void LoginWithEmptyFieldsShouldFail()
	{
		IWebElement loginLink = wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("Login")));
		loginLink.Click();

		Assert.That(driver.Url, Is.EqualTo(baseUrl + "/login"));
		Assert.That(driver.FindElement(By.TagName("form")).Displayed, Is.True);

		driver.FindElement(By.ClassName("login")).Click();

		alert = driver.SwitchTo().Alert();
		Assert.That(alert.Text, Is.EqualTo("No empty fields allowed!"));
		alert.Accept();

		Assert.That(driver.Url, Is.EqualTo(baseUrl + "/login"));
	}
}