using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using MVCIntroDemo.Models.Product;
using System.Text;
using System.Text.Json;

namespace MVCIntroDemo.Controllers
{
	public class ProductController : Controller
	{
		private IEnumerable<ProductViewModel> _products = new List<ProductViewModel>()
		{ 
			new ProductViewModel()
			{
				Id = 1,
				Name = "Cheese",
				Price = 7.00m
			},
			new ProductViewModel()
			{
				Id = 2,
				Name = "Ham",
				Price = 5.50m
			},
			new ProductViewModel()
			{
				Id = 3,
				Name = "Bread",
				Price = 1.50m
			}
		};

		[ActionName("My-Products")]
		public IActionResult All(string keyword)
		{
            if (keyword != null)
            {
				var foundProduct = _products
					.Where(p => p.Name
					.ToLower()
					.Contains(keyword.ToLower()));

				return View(foundProduct);
            }

            return View(_products);
		}

		public IActionResult ByID(int id)
		{
			var product = _products
				.FirstOrDefault(p => p.Id == id);

            if (product == null)
				return NotFound();
            
            return View(product);
		}

		public IActionResult AllAsJson()
		{
			return Json(_products, new JsonSerializerOptions
			{
				WriteIndented = true,
			});
		}

		public IActionResult AllAsText()
		{
			var text = string.Empty;
            foreach (var product in _products)
            {
				text += $"Product {product.Id}: {product.Name} - {product.Price} lv.{Environment.NewLine}";
            }

			return Content(text);
        }

		public IActionResult AllAsTextFile()
		{
			StringBuilder sb = new StringBuilder();
            foreach (var product in _products)
            {
				sb.AppendLine($"Product {product.Id}: {product.Name} - {product.Price} lv.{Environment.NewLine}");
			}

			Response.Headers.Add(HeaderNames.ContentDisposition, @"attachment;filename=products.txt");

			return File(Encoding.UTF8.GetBytes(sb.ToString().Trim()), "text/plain");
        }
	}
}
