using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeaCenterPOM.Pages
{
	public class MyIdeasPage : BasePage
	{
		public MyIdeasPage(IWebDriver driver) : base(driver) { }

		public override string PageUrl => base.PageUrl + "/Ideas/MyIdeas";

		public ReadOnlyCollection<IWebElement> Ideas => driver
			.FindElements(By.XPath("//div[@class='card-body']"));

		public string IdeasDescription => Ideas
			.Last()
			.FindElement(By.XPath(".//p[@class='card-text']")).Text.Trim();

		public IWebElement ViewButton => Ideas
			.Last()
			.FindElement(By.XPath(".//a[contains(@href, '/Ideas/Read')]"));

		public IWebElement EditButton => Ideas
			.Last()
			.FindElement(By.XPath(".//a[contains(@href, '/Ideas/Edit')]"));

		public IWebElement DeleteButton => Ideas
			.Last()
			.FindElement(By.XPath(".//a[contains(@href, '/Ideas/Delete')]"));
	}
}
