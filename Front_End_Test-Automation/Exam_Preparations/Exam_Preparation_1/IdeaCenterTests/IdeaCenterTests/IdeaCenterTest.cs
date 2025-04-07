using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Collections.ObjectModel;

namespace IdeaCenterNoPOM
{
	[TestFixture]
	public class Tests
	{
		IWebDriver driver;
		WebDriverWait wait;
		private string pageUrl = "http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com:83";
		private string lastCreatedIdeaTitle;
		private string lastCreatedIdeaDescription;
		IJavaScriptExecutor js;

		[OneTimeSetUp]
		public void OneTimeSetup()
		{
			ChromeOptions options = new ChromeOptions();
			options.AddUserProfilePreference("profile.password_manager_enabled", false);
			options.AddArgument("--disable-search-engine-choice-screen");

			driver = new ChromeDriver();
			driver.Manage().Window.Maximize();
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
			driver.Navigate().GoToUrl(pageUrl);

			js = (IJavaScriptExecutor)driver;
			wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));

			LoginUser("testUser_123@email.com", "test1234");
		}

		[OneTimeTearDown]
		public void OneTimeTearDown()
		{
			driver.Quit();
			driver.Dispose();
		}

		[Test, Order(1)]
		public void Test_CreateIdeaWithInvalidData()
		{
			driver.Navigate().GoToUrl(pageUrl + "/Ideas/Create");

			driver.FindElement(By.XPath("//input[@name='Title']"))
				.SendKeys("");
			driver.FindElement(By.XPath("//textarea[@name='Description']"))
				.SendKeys("");
			driver.FindElement(By.XPath("//button[@class='btn btn-primary btn-lg']"))
				.Click();

			Assert.That(wait.Until(ExpectedConditions.UrlContains("/Ideas/Creat")), Is.True);
			//Assert.That(driver.Url, Does.Contain("/Ideas/Create"));

			string mainErrMsg = driver.FindElement(By.XPath("//div[@class='text-danger validation-summary-errors']/ul/li")).Text;
			string titleErrMsg = driver.FindElement(By.XPath("//span[@data-valmsg-for='Title']")).Text;
			string descErrMsg = driver.FindElement(By.XPath("//span[@data-valmsg-for='Description']")).Text;

			Assert.That(titleErrMsg, Is.EqualTo("The Title field is required."));
			Assert.That(mainErrMsg, Is.EqualTo("Unable to create new Idea!"));
			Assert.That(descErrMsg, Is.EqualTo("The Description field is required."));
		}

		[Test, Order(2)]
		public void Test_CreateIdeaWithRandomData()
		{
			driver.Navigate().GoToUrl(pageUrl + "/Ideas/Create");

			lastCreatedIdeaTitle = "testIdea_" + GenerateRandomString(4);
			lastCreatedIdeaDescription = "testDescription_" + GenerateRandomString(4);

			driver.FindElement(By.XPath("//input[@name='Title']"))
				.SendKeys(lastCreatedIdeaTitle);
			driver.FindElement(By.XPath("//textarea[@name='Description']"))
				.SendKeys(lastCreatedIdeaDescription);
			driver.FindElement(By.XPath("//button[@class='btn btn-primary btn-lg']"))
				.Click();

			//Assert.That(driver.Url, Does.Contain("/Ideas/MyIdeas"));
			Assert.That(wait.Until(ExpectedConditions.UrlContains("/Ideas/MyIdeas")), Is.True);

			ReadOnlyCollection<IWebElement> ideas = driver.FindElements(By.XPath("//div[@class='card-body']"));

			Assert.That(ideas
				.Last()
				.FindElement(By.XPath("./p[@class='card-text']"))
				.Text, Is.EqualTo(lastCreatedIdeaDescription));
		}

		[Test, Order(3)]
		public void Test_ViewLastCreatedIdea()
		{
			driver.Navigate().GoToUrl(pageUrl + "/Ideas/MyIdeas");

			ReadOnlyCollection<IWebElement> ideas = driver.FindElements(By.XPath("//div[@class='card-body']"));
			IWebElement viewBtn = ideas.Last().FindElement(By.XPath(".//a[contains(@href, '/Ideas/Read')]"));
			js.ExecuteScript("arguments[0].click();", viewBtn);

			Assert.That(driver.FindElement(By.XPath("//div[@id='intro']/h1")).Text, Is.EqualTo(lastCreatedIdeaTitle));
		}

		[Test, Order(4)]
		public void Test_EditLastCreatedIdea()
		{
			driver.Navigate().GoToUrl(pageUrl + "/Ideas/MyIdeas");
			ReadOnlyCollection<IWebElement> ideas = driver.FindElements(By.XPath("//div[@class='card-body']"));
			IWebElement editBtn = ideas.Last().FindElement(By.XPath(".//a[contains(@href, '/Ideas/Edit')]"));
			js.ExecuteScript("arguments[0].click();", editBtn);

			IWebElement titleField = driver.FindElement(By.XPath("//input[@name='Title']"));
			//IWebElement descField = driver.FindElement(By.XPath("//textarea[@name='Description']"));

			lastCreatedIdeaTitle = "Changed Title: " + lastCreatedIdeaTitle;
			titleField.Clear();
			titleField.SendKeys(lastCreatedIdeaTitle);

			driver.FindElement(By.XPath("//button[@type='submit']"))
				.Click();

			ideas = driver.FindElements(By.XPath("//div[@class='card-body']"));
			IWebElement viewBtn = ideas.Last().FindElement(By.XPath(".//a[contains(@href, '/Ideas/Read')]"));
			js.ExecuteScript("arguments[0].click();", viewBtn);

			Assert.That(driver.FindElement(By.XPath("//div[@id='intro']/h1")).Text, Is.EqualTo(lastCreatedIdeaTitle));

		}

		[Test, Order(5)]
		public void Test_EditIdeaDescription()
		{
			driver.Navigate().GoToUrl(pageUrl + "/Ideas/MyIdeas");
			ReadOnlyCollection<IWebElement> ideas = driver.FindElements(By.XPath("//div[@class='card-body']"));
			IWebElement editBtn = ideas.Last().FindElement(By.XPath(".//a[contains(@href, '/Ideas/Edit')]"));
			js.ExecuteScript("arguments[0].click();", editBtn);

			IWebElement descField = driver.FindElement(By.XPath("//textarea[@name='Description']"));

			lastCreatedIdeaDescription = "Changed Description: " + lastCreatedIdeaDescription;
			descField.Clear();
			descField.SendKeys(lastCreatedIdeaDescription);

			driver.FindElement(By.XPath("//button[@type='submit']"))
				.Click();

			ideas = driver.FindElements(By.XPath("//div[@class='card-body']"));
			IWebElement viewBtn = ideas.Last().FindElement(By.XPath(".//a[contains(@href, '/Ideas/Read')]"));
			js.ExecuteScript("arguments[0].click();", viewBtn);

			Assert.That(driver.FindElement(By.XPath("//p[@class='offset-lg-3 col-lg-6']")).Text, Is.EqualTo(lastCreatedIdeaDescription));
		}

		[Test, Order(6)]
		public void Test_DeleteLastCreatedIdea()
		{
			driver.Navigate().GoToUrl(pageUrl + "/Ideas/MyIdeas");

			ReadOnlyCollection<IWebElement> ideas = driver.FindElements(By.XPath("//div[@class='card-body']"));
			IWebElement deleteBtn = ideas.Last().FindElement(By.XPath(".//a[contains(@href, '/Ideas/Delete')]"));
			js.ExecuteScript("arguments[0].click();", deleteBtn);

			ideas = driver.FindElements(By.XPath("//div[@class='card-body']"));

			bool isIdeaDeleted = ideas.All(idea => !idea.Text.Contains(lastCreatedIdeaDescription));
			Assert.That(isIdeaDeleted, Is.True);
		}

		public void LoginUser(string email, string pass)
		{
			driver.FindElement(By.XPath("//a[@class='btn btn-outline-info px-3 me-2' and @href='/Users/Login']"))
				.Click();

			IWebElement emailField = driver.FindElement(By.XPath("//input[@name='Email']"));
			IWebElement passField = driver.FindElement(By.XPath("//input[@name='Password']"));

			emailField.SendKeys(email);
			passField.SendKeys(pass);
			driver.FindElement(By.XPath("//button[@class='btn btn-primary btn-lg btn-block']"))
				.Click();

			Assert.That(driver.Url, Does.Contain("/"));
		}

		public string GenerateRandomString(int length)
		{
			var rnd = new Random();
			const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
			return new string(Enumerable.Repeat(chars, length)
				.Select(s => s[rnd.Next(s.Length)]).ToArray());
		}
	}
}