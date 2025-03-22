using OpenQA.Selenium;

namespace SaucedemoPOM.Pages
{
	public class InventoryPage : BasePage
	{
		public InventoryPage(IWebDriver driver) : base(driver)
		{
		}

		private readonly By cartLink = By.ClassName("shopping_cart_link");
		private readonly By productsTitle = By.ClassName("title");
		private readonly By inventoryItems = By.ClassName("inventory_item");

		public void AddToCartByIndex(int itemIndex)
		{
			By itemAddToCartButton = By.CssSelector($".inventory_item:nth-child({itemIndex + 1}) .btn_inventory");
			Click(itemAddToCartButton);
		}

		public void AddToCartByName(string productName)
		{
			By itemAddToCartButton = By.XPath($"//div[text()='{productName}']/ancestor::div[@class='inventory_item']//button");
			Click(itemAddToCartButton);
		}

		public void ClickCartLink()
		{
			Click(cartLink);
		}

		public bool isInventoryDisplayed()
		{
			return FindElements(inventoryItems).Any();
		}

		public bool isPageLoaded()
		{
			return GetText(productsTitle) == "Products" && _driver.Url.Contains("/inventory.html");
		}
	}
}
 