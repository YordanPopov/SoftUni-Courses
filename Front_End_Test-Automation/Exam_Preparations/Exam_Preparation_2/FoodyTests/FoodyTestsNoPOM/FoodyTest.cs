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
		private IWebDriver driver;
		private WebDriverWait wait;
		private Actions actions;
		private string pageUrl = "http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com:85";
		private static string foodName;
		private static string foodDescription;

		[OneTimeSetUp]
        public void OneTimeSetUp()
        {
			ChromeOptions options = new ChromeOptions();
			options.AddUserProfilePreference("profile.password_manager_enabled", false);
			options.AddArgument("--disable-search-engine-choice-screen");

			driver = new ChromeDriver(options);
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
			driver.Manage().Window.Maximize();

			wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));

			driver.Navigate().GoToUrl(pageUrl + "/User/Login");
			LoginUser("testUser_123", "test1234");
		}

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
			driver.Quit();
			driver.Dispose();
        }

        [Test, Order(1)]
        public void Test_AddFoodWithInvalidData()
		{ 			
            driver.Navigate().GoToUrl(pageUrl + "/Food/Add");

			driver.FindElement(By.XPath("//input[@name='Name']"))
				.SendKeys("");
			driver.FindElement(By.XPath("//input[@name='Description']"))
				.SendKeys("");
			driver.FindElement(By.XPath("//button[@type='submit']"))
				.Click();

			string mainErroMsg = driver.FindElement(By.XPath("//div[@class='text-danger validation-summary-errors']/ul/li"))
				.Text
				.Trim();

			Assert.That(wait.Until(ExpectedConditions.UrlContains($"{pageUrl}/Food/Add")), Is.True);
			Assert.That(mainErroMsg, Is.EqualTo("Unable to add this food revue!"));
		}

        [Test, Order(2)]
        public void Test_AddFoodWithRandomData()
        {
			foodName = "Name-" + GenerateRandomString(4);
			foodDescription = "Description-" + GenerateRandomString(4);

			driver.Navigate().GoToUrl(pageUrl + "/Food/Add");

			driver.FindElement(By.XPath("//input[@name='Name']"))
				.SendKeys(foodName);
			driver.FindElement(By.XPath("//input[@name='Description']"))
				.SendKeys(foodDescription);
			driver.FindElement(By.XPath("//button[@type='submit']"))
				.Click();

			Assert.That(wait.Until(ExpectedConditions.UrlContains($"{pageUrl}/")), Is.True);

			string lastCreatedFoodName = driver
				.FindElement(By.XPath("(//section[@id='scroll']//h2[@class='display-4'])[last()]"))
				.Text
				.Trim();

			Assert.That(lastCreatedFoodName, Is.EqualTo(foodName));
		}

		[Test, Order(3)]
		public void Test_EditLassAddedFood()
		{
			actions = new Actions(driver);
			ReadOnlyCollection<IWebElement> foods = driver.FindElements(By.XPath("//section[@id='scroll']/div[@class='container px-5']"));
			IWebElement editBtn = foods.Last().FindElement(By.XPath(".//a[contains(@href, '/Food/Edit')]"));
			actions.MoveToElement(editBtn)
				.Click()
				.Perform();

			string updatedName = "Updated-" + foodName;

			IWebElement nameField = driver.FindElement(By.XPath("//input[@name='Name']"));
			nameField.Clear();
			nameField.SendKeys(updatedName);

			driver.FindElement(By.XPath("//button[@type='submit']")).Click();

			string lastFoodName = driver
				.FindElement(By.XPath("(//section[@id='scroll']//h2[@class='display-4'])[last()]"))
				.Text
				.Trim();

			Assert.That(lastFoodName, Is.EqualTo(foodName));
			Console.WriteLine("Title remains unchanged!!!");
		}

		[Test, Order(4)]
		public void Test_SearchForFoodTitle()
		{
			driver.FindElement(By.XPath("//input[@type='search']"))
				.SendKeys(foodName);
			driver.FindElement(By.XPath("//button[@class='btn btn-primary rounded-pill mt-5 col-2']"))
				.Click();

			ReadOnlyCollection<IWebElement> foods = driver.FindElements(By.XPath("//section[@id='scroll']/div[@class='container px-5']"));

			Assert.That(foods.Count, Is.EqualTo(1));

			string findedFoodname = foods.First().FindElement(By.XPath(".//div[@class='p-5']/h2"))
				.Text
				.Trim();

			Assert.That(findedFoodname, Is.EqualTo(foodName));
		}

		[Test, Order(5)]
		public void Test_DeleteLastAddedFood()
		{
			actions = new Actions(driver);
			driver.Navigate().GoToUrl(pageUrl + "/");

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
			Assert.That(lastFoodName, Is.Not.EqualTo(foodName));
		}

		[Test, Order(6)]
		public void Test_SearcForDeletedFood()
		{
			driver.Navigate().GoToUrl(pageUrl + "/");
			driver.FindElement(By.XPath("//input[@type='search']"))
				.SendKeys(foodName);
			driver.FindElement(By.XPath("//button[@class='btn btn-primary rounded-pill mt-5 col-2']"))
				.Click();

			//IWebElement noFoodMsg = driver.FindElement(By.XPath("//h2[@class='display-4']"));
			IWebElement noFoodMsg = wait.Until(drv => drv.FindElement(By.XPath("//h2[@class='display-4']")));
			//IWebElement addFoodBtn = driver.FindElement(By.XPath("//a[@class='btn btn-primary btn-xl rounded-pill mt-5']"));
			IWebElement addFoodBtn = wait.Until(drv => drv.FindElement(By.XPath("//a[@class='btn btn-primary btn-xl rounded-pill mt-5']")));

			Assert.That(noFoodMsg.Displayed, Is.True);
			Assert.That(noFoodMsg.Text, Is.EqualTo("There are no foods :("));
			Assert.That(addFoodBtn.Displayed, Is.True);
		}

		public void LoginUser(string uName, string pass)
		{
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