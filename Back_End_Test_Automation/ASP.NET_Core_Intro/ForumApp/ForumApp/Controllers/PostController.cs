using ForumApp.Data;
using ForumApp.Data.Models;
using ForumApp.Models.Post;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ForumApp.Controllers
{
	public class PostController : Controller
	{
		private readonly ForumAppDbContext _dbContext;

		public PostController(ForumAppDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<IActionResult> All()
		{
			var posts = await _dbContext
				.Posts
				.Select(p => new PostViewModel()
				{
					Id = p.Id,
					Title = p.Title,
					Content = p.Content,
				})
				.ToListAsync();

			return View(posts);
		}

		public async Task<IActionResult> Add()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Add(PostFormModel model)
		{
			var post = new Post()
			{
				Title = model.Title,
				Content = model.Content,
			};

			await _dbContext.Posts.AddAsync(post);
			await _dbContext.SaveChangesAsync();

			return RedirectToAction("All");
		}

		public async Task<IActionResult> Edit(int id)
		{
			var post = await _dbContext.Posts.FindAsync(id);

			return View(new PostFormModel()
			{
				Title = post.Title,
				Content = post.Content,
			});
		}

		[HttpPost]
		public async Task<IActionResult> Edit(int id, PostFormModel model)
		{
			var post = await _dbContext.Posts.FindAsync(id);

			post.Title = model.Title;
			post.Content = model.Content;

			await _dbContext.SaveChangesAsync();

			return RedirectToAction("All");
		}

		[HttpPost]
		public async Task<IActionResult> Delete(int id)
		{
			var post = await _dbContext.Posts.FindAsync(id);
			
			_dbContext.Posts.Remove(post);
			await _dbContext.SaveChangesAsync();

			return RedirectToAction("All");
		}
	}
}
