using OpenQA.Selenium;

namespace SaucedemoPOM.Pages
{
	public class HiddenMenuPage : BasePage
	{
		public HiddenMenuPage(IWebDriver driver) : base(driver) { }

		private readonly By menuButton = By.Id("react-burger-menu-btn");
		private readonly By logoutButton = By.Id("logout_sidebar_link");
		private readonly By allItemsButton = By.Id("inventory_sidebar_link");
		private readonly By aboutButton = By.Id("about_sidebar_link");
		private readonly By resetStateButton = By.Id("reset_sidebar_link");

		public void ClickMenuButton()
		{
			Click(menuButton);
		}

		public void ClickLogoutButton()
		{
			Click(logoutButton);
		}

		public bool IsMenuOpened()
		{
			return FindElement(logoutButton).Displayed;
		}
	}
}
