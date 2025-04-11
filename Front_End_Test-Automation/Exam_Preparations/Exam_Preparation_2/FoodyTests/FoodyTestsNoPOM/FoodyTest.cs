using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Collections.ObjectModel;

namespace FoodyTestsNoPOM
{
	[TestFixture]
	public class Tests
	{
		IWebDriver driver;

		WebDriverWait wait;

		Actions actions;

		private string pageUrl = "http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com:85";

		private string lastCreatedFoodName;

		private string lastCreatedFoodDescription;

		[OneTimeSetUp]
		public void OneTimeSetUp()
		{
			ChromeOptions options = new ChromeOptions();
			options.AddUserProfilePreference("profile.password_manager_enabled", false);
			options.AddArgument("--disable-search-engine-choice-screen");

			driver = new ChromeDriver(options);
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
			driver.Manage().Window.Maximize();
			driver.Navigate().GoToUrl(pageUrl);

			wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
			actions = new Actions(driver);

			LoginUser("testUser_123", "test1234");
		}

		[OneTimeTearDown]
		public void OneTimeTearDown()
		{
			driver.Quit();
			driver.Dispose();
		}

		[SetUp]
		public void Setup()
		{
			driver.Navigate().GoToUrl(pageUrl + "/");
		}

		[Test, Order(1)]
		public void Test_AddFoodWithInvalidData()
		{
			driver.Navigate().GoToUrl(pageUrl + "/Food/Add");

			driver.FindElement(By.Name("Name")).SendKeys("");
			driver.FindElement(By.Name("Description")).SendKeys("");
			driver.FindElement(By.XPath("//button[@type='submit']")).Click();

			string mainErroMsg = driver.FindElement(By.XPath("//div[@class='text-danger validation-summary-errors']/ul/li")).Text.Trim();

			Assert.That(wait.Until(ExpectedConditions.UrlToBe($"{pageUrl}/Food/Add")), Is.True);
			Assert.That(mainErroMsg, Is.EqualTo("Unable to add this food revue!"));
		}

		[Test, Order(2)]
		public void Test_AddFoodWithRandomData()
		{
			lastCreatedFoodName = $"NAME-{GenerateRandomString(4)}";
			lastCreatedFoodDescription = $"DESCRIPTION-{GenerateRandomString(4)}";

			driver.Navigate().GoToUrl(pageUrl + "/Food/Add");

			driver.FindElement(By.Name("Name")).SendKeys(lastCreatedFoodName);
			driver.FindElement(By.Name("Description")).SendKeys(lastCreatedFoodDescription);

			driver.FindElement(By.XPath("//button[@type='submit']"))
				.Click();

			Assert.That(wait.Until(ExpectedConditions.UrlToBe($"{pageUrl}/")), Is.True);

			string lastFoodName = driver
				.FindElement(By.XPath("(//section[@id='scroll']//h2[@class='display-4'])[last()]"))
				.Text
				.Trim();

			Assert.That(lastFoodName, Is.EqualTo(lastCreatedFoodName));
		}

		[Test, Order(3)]
		public void Test_EditLassAddedFood()
		{
			string updatedName;
			string lastFoodName;
			ReadOnlyCollection<IWebElement> foods = driver.FindElements(By.XPath("//section[@id='scroll']/div[@class='container px-5']"));

			IWebElement editBtn = foods.Last().FindElement(By.XPath(".//a[contains(@href, '/Food/Edit')]"));

			actions.MoveToElement(editBtn)
				.Click()
				.Perform();

			updatedName = $"UPDATED-{lastCreatedFoodName}";

			IWebElement nameField = driver.FindElement(By.Name("Name"));
			nameField.Clear();
			nameField.SendKeys(updatedName);
			driver.FindElement(By.XPath("//button[@type='submit']")).Click();

			lastFoodName = driver
				.FindElement(By.XPath("(//section[@id='scroll']//h2[@class='display-4'])[last()]"))
				.Text
				.Trim();

			Assert.That(lastFoodName, Is.EqualTo(lastCreatedFoodName));
			Console.WriteLine("Title remains unchanged!!!");
		}

		[Test, Order(4)]
		public void Test_SearchForFoodTitle()
		{
			driver.FindElement(By.XPath("//input[@type='search']")).SendKeys(lastCreatedFoodName);
			driver.FindElement(By.XPath("//button[@class='btn btn-primary rounded-pill mt-5 col-2']"))
				.Click();

			ReadOnlyCollection<IWebElement> foods = wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//section[@id='scroll']/div[@class='container px-5']")));

			Assert.That(foods.Count, Is.EqualTo(1));

			string findedFoodName = foods.First().FindElement(By.XPath(".//div[@class='p-5']/h2"))
				.Text
				.Trim();

			Assert.That(findedFoodName, Is.EqualTo(lastCreatedFoodName));
		}

		[Test, Order(5)]
		public void Test_DeleteLastAddedFood()
		{
			ReadOnlyCollection<IWebElement> foods = driver.FindElements(By.XPath("//section[@id='scroll']/div[@class='container px-5']"));
			int initialCount = foods.Count;

			IWebElement lastFoodDeleteBtn = foods.Last().FindElement(By.XPath(".//a[contains(@href, '/Food/Delete')]"));
			actions.MoveToElement(lastFoodDeleteBtn)
				.Click()
				.Perform();

			foods = driver.FindElements(By.XPath("//section[@id='scroll']/div[@class='container px-5']"));
			int countAfterDeletion = foods.Count;

			string lastFoodName = foods.Last().FindElement(By.XPath(".//div[@class='p-5']/h2"))
				.Text
				.Trim();

			Assert.That(countAfterDeletion, Is.EqualTo(initialCount - 1));
			Assert.That(lastFoodName, Is.Not.EqualTo(lastCreatedFoodName));
		}

		[Test, Order(6)]
		public void Test_SearchForDeletedFood()
		{
			driver.FindElement(By.XPath("//input[@type='search']")).SendKeys(lastCreatedFoodName);
			driver.FindElement(By.XPath("//button[@class='btn btn-primary rounded-pill mt-5 col-2']"))
				.Click();

			IWebElement noFoodMsg = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//h2[@class='display-4']")));
			IWebElement addFoodBtn = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//a[@class='btn btn-primary btn-xl rounded-pill mt-5']")));

			Assert.Multiple(() =>
			{
				Assert.That(noFoodMsg.Displayed, Is.True);
				Assert.That(noFoodMsg.Text, Is.EqualTo("There are no foods :("));
				Assert.That(addFoodBtn.Displayed, Is.True);
			});
		}

		public void LoginUser(string uName, string pass)
		{
			driver.Navigate().GoToUrl(pageUrl + "/User/Login");

			driver.FindElement(By.XPath("//input[@name='Username']"))
				.SendKeys(uName);
			driver.FindElement(By.XPath("//input[@name='Password']"))
				.SendKeys(pass);
			driver.FindElement(By.XPath("//button[@type='submit']")).Click();
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