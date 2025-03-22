using SaucedemoPOM.Pages;

namespace SaucedemoPOM.Tests
{
	[TestFixture]
	public class LoginTests : BaseTest
	{
		public enum ErrorMessageType
		{
			InvalidCredentials,
			PasswordRequired,
			UsernameRequired
		}

		public Dictionary<ErrorMessageType, string> errorMessages = new()
		{
			{ ErrorMessageType.UsernameRequired, "Epic sadface: Username is required"},
			{ ErrorMessageType.PasswordRequired, "Epic sadface: Password is required" },
			{ ErrorMessageType.InvalidCredentials, "Epic sadface: Username and password do not match any user in this service" }
		};

	[Test]
	public void Test_LoginPage_WithValidCredentials()
	{
		Login("standard_user", "secret_sauce");

		var inventoryPage = new InventoryPage(_driver);

		Assert.That(inventoryPage.isPageLoaded(), Is.True);
	}

	[TestCase("invalidUser", "invalidPassword", ErrorMessageType.InvalidCredentials)]
	[TestCase("", "", ErrorMessageType.UsernameRequired)]
	[TestCase("   ", "   ", ErrorMessageType.InvalidCredentials)]
	[TestCase("standard_user", "", ErrorMessageType.PasswordRequired)]
	[TestCase("standard_user", "invalidPassword", ErrorMessageType.InvalidCredentials)]
	[TestCase("standard_user", "  ", ErrorMessageType.InvalidCredentials)]
	public void Test_LoginPage_WithInvalidCredentials(string username, string password, ErrorMessageType errorType)
	{
		Login(username, password);

		var loginPage = new LoginPage(_driver);
		string err = loginPage.GetErrorMessage();
		Assert.That(err, Is.Not.Empty);
		Assert.That(err, Does.Contain(errorMessages[errorType]));
	}

	[Test]
	public void Test_LoginPage_WithLockedOutUser()
	{
		Login("locked_out_user", "secret_sauce");

		var loginPage = new LoginPage(_driver);
		string err = loginPage.GetErrorMessage();
		Assert.That(err, Is.Not.Empty);
		Assert.That(err, Does.Contain("Epic sadface: Sorry, this user has been locked out."));
	}
}
}
