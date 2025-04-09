using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeaCenterPOM.Pages
{
	public class ViewIdeaPage : BasePage
	{
		public ViewIdeaPage(IWebDriver driver) : base(driver) { }

		public string IdeaTitle => driver.FindElement(By.XPath("//div[@id='intro']/h1")).Text.Trim();

		public string IdeaDescription => driver.FindElement(By.XPath("//section[@class='row']/p")).Text.Trim();
	}
}
