using OpenQA.Selenium;

namespace SaucedemoPOM.Pages
{
	public class CheckoutPage : BasePage
	{
		public CheckoutPage(IWebDriver driver) : base(driver)
		{
		}

		private readonly By firstNameField = By.Id("first-name");
		private readonly By lastNameField = By.Id("last-name");
		private readonly By postalCodeField = By.Id("postal-code");
		private readonly By continueButton = By.Id("continue");
		private readonly By finishButton = By.Id("finish");
		private readonly By completeHeader = By.ClassName("complete-header");

		public void EnterFirstName(string firstName)
		{
			Type(firstNameField, firstName);
		}

		public void EnterLastName(string lastName)
		{
			Type(lastNameField, lastName);
		}

		public void EnterPostalCode(string postalCode)
		{
			Type(postalCodeField, postalCode);
		}

		public void ClickContiunue()
		{
			Click(continueButton);
		}

		public void ClickFinish()
		{
			Click(finishButton);
		}

		public bool IsPageLoaded()
		{
			return _driver.Url.Contains("/chechout-step-one") || _driver.Url.Contains("/checkout-step-two");
		}

		public bool IsCheckoutComplete()
		{
			return GetText(completeHeader) == "Thank you for your order!";
		}
	}
}
