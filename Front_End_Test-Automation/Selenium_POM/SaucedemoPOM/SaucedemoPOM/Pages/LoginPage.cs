using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V132.Storage;

namespace SaucedemoPOM.Pages
{
	public class LoginPage : BasePage
	{
		public LoginPage(IWebDriver driver) : base(driver)
		{
		}

		private readonly By usernameField = By.Id("user-name");
		private readonly By passwordField = By.Id("password");
		private readonly By loginButton = By.Id("login-button");
		private readonly By errorMsg = By.XPath("//h3[@data-test='error']");

		public void InputUsername(string text)
		{
			Type(usernameField, text);
		}

		public void InputPassword(string text)
		{
			Type(passwordField, text);
		}

		public void ClickLoginButton()
		{
			Click(loginButton);
		}

		public string GetErrorMessage()
		{
			return GetText(errorMsg);
		}
	}
}
