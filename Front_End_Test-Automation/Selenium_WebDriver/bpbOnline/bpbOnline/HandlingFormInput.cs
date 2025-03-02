using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V131.HeapProfiler;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;

namespace bpbOnline
{
    public class HandlingFormInput
    {
        private IWebDriver _driver;
        private string url = "http://practice.bpbonline.com/";

		[SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl(url);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
        }

        [Test]
        public void Handling_Form_Input()
        {
            _driver.FindElement(By.XPath("//span[text()='My Account']")).Click();
            _driver.FindElement(By.XPath("//span[text()='Continue']")).Click();
            Assert.That(_driver.FindElement(By.XPath("//form[@name='create_account']")).Displayed, Is.True);

            var rnd = new Random();
            string userEmail = $"testUser_{rnd.Next(1000, 9999)}@email.com";

            _driver.FindElement(By.XPath("//input[@value='m']")).Click();
            _driver.FindElement(By.Name("firstname")).SendKeys("testUserFirstName");
            _driver.FindElement(By.Name("lastname")).SendKeys("testUserLastName");
            _driver.FindElement(By.Name("dob")).SendKeys("01/01/1970" + Keys.Enter);
            _driver.FindElement(By.Name("email_address")).SendKeys(userEmail);
            _driver.FindElement(By.Name("company")).SendKeys("testCompanyName");
            _driver.FindElement(By.Name("street_address")).SendKeys("testStreetAddress");
            _driver.FindElement(By.Name("suburb")).SendKeys("testSuburb");
            _driver.FindElement(By.Name("postcode")).SendKeys("testPostCode");
			_driver.FindElement(By.Name("city")).SendKeys("testCityName");
			_driver.FindElement(By.Name("state")).SendKeys("testStateName");

            IWebElement countryDropdown = _driver.FindElement(By.Name("country"));
            SelectElement selectCountry = new SelectElement(countryDropdown);
            selectCountry.SelectByText("Bulgaria");

            _driver.FindElement(By.Name("telephone")).SendKeys("0888999777");
			_driver.FindElement(By.Name("fax")).SendKeys("00-11-2-11-3");
			_driver.FindElement(By.Name("newsletter")).Click();
			_driver.FindElement(By.Name("password")).SendKeys("test1234");
			_driver.FindElement(By.Name("confirmation")).SendKeys("test1234");
            _driver.FindElement(By.XPath("//span[text()='Continue']")).Click();

            Assert.That(_driver.Url, Does.Contain("/create_account_success.php"));
            Assert.That(_driver.PageSource, Does.Contain("Your Account Has Been Created!"));
            _driver.FindElement(By.XPath("//span[text()='Continue']")).Click();
		}

        [Test]
        public void Working_With_Web_Tables()
        {
            IWebElement productTable = _driver.FindElement(By.XPath("//div[@class='contentText']/table"));
            ReadOnlyCollection<IWebElement> tableRows = _driver.FindElements(By.XPath("//tbody/tr"));

            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filePath = Path.Combine(desktopPath, "productInformation.csv");

			if (File.Exists(filePath))
			{
                File.Delete(filePath);
			}

			foreach (var tRow in tableRows)
			{
                ReadOnlyCollection<IWebElement> tableCols = tRow.FindElements(By.XPath("td"));
				foreach (var tCol in tableCols)
				{
					string data = tCol.Text;
                    string[] productInfo = data.Split('\n');
                    string printProductInfo = productInfo[0].Trim() + "," + productInfo[1].Trim() + Environment.NewLine;



                    File.AppendAllText(filePath, printProductInfo);
				}
			}

            Assert.That(File.Exists(filePath), Is.True);
            Assert.That(new FileInfo(filePath).Length, Is.GreaterThan(0));
		}

        [Test]
        public void Dropdown_Practice()
        {
			string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
			string filePath = Path.Combine(desktopPath, "manufacturer.txt");

			if (File.Exists(filePath))
			{
				File.Delete(filePath);
			}

            SelectElement manufacturerDropdown = new SelectElement(_driver.FindElement(By.Name("manufacturers_id")));
            IList<IWebElement> allManufacturers = manufacturerDropdown.Options;

            List<string> manufNames = new List<string>();

			foreach (var manufName in allManufacturers)
			{
                manufNames.Add(manufName.Text);  
			}

            manufNames.RemoveAt(0);

			foreach (string mname in manufNames)
			{
                manufacturerDropdown.SelectByText(mname);
				manufacturerDropdown = new SelectElement(_driver.FindElement(By.XPath("//select[@name='manufacturers_id']")));

                if (_driver.PageSource.Contains("There are no products available in this category."))
                {
                    File.AppendAllText(filePath, $"The manufacturer {mname} has no products\n");
                }
                else
                {
                    IWebElement productTable = _driver.FindElement(By.XPath("//table[@class=\"productListingData\"]"));
                    File.AppendAllText(filePath, $"\n\nThe manufacturer {mname} products are listed--\n");
                    ReadOnlyCollection<IWebElement> rows = _driver.FindElements(By.XPath("//tbody/tr"));

                    foreach (var row in rows)
                    {                
                        File.AppendAllText(filePath, row.Text + Environment.NewLine);
                    }
                }
			}
		}

        [TearDown]
        public void TearDown() { 
            _driver.Quit();
            _driver.Dispose();
        }
    }
}