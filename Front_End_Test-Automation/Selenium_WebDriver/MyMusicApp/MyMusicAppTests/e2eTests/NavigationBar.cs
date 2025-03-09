using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace e2eTests;

public class NavigationBar
{
	IWebDriver driver;
	WebDriverWait wait;
	private string baseUrl = "http://localhost:3000";

	[SetUp]
	public void Setup()
	{
		driver = new ChromeDriver();
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
	public void VerifyNavigationBarForLoggedInUsers()
	{
		IWebElement loginLink = wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("Login")));
		loginLink.Click();

		Assert.That(driver.Url, Is.EqualTo(baseUrl + "/login"));
		Assert.That(driver.FindElement(By.TagName("form")).Displayed, Is.True);

		driver.FindElement(By.Id("email")).SendKeys(TestContext.RegisteredUser.UserEmail);
		driver.FindElement(By.Id("password")).SendKeys(TestContext.RegisteredUser.Password);
		driver.FindElement(By.ClassName("login")).Click();

		Assert.That(driver.Url, Is.EqualTo(baseUrl + "/"));
		Assert.That(driver.FindElement(By.LinkText("Create Album")).Displayed, Is.True);
		Assert.That(driver.FindElement(By.LinkText("Logout")).Displayed, Is.True);

		driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);

		try
		{
			wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("Login")));
			Assert.Fail("Login link is visible for logged-in user!!!");
		}
		catch (WebDriverTimeoutException ex)
		{
			Assert.Pass("Login link is not visible!");
		}

		try
		{
			wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("Register")));
			Assert.Fail("Register link is visible for logged-in user!!!");
		}
		catch (WebDriverTimeoutException ex)
		{
			Assert.Pass("Register link is not visible!");
		}

		driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
	}
}
