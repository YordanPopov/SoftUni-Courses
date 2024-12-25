using ForumApp.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ForumApp.Data
{
	public class ForumAppDbContext : DbContext
	{
		public ForumAppDbContext(DbContextOptions<ForumAppDbContext> options) :base(options)
		{
			Database.Migrate();
		}

		public DbSet<Post> Posts { get; set; }

		private Post FirstPost { get; set; }
		private Post SecondPost { get; set; }
		private Post ThirdPost { get; set; }


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			SeedPost();
			modelBuilder
				.Entity<Post>()
				.HasData(FirstPost, SecondPost, ThirdPost);

			base.OnModelCreating(modelBuilder);
		}
		private void SeedPost()
		{
			FirstPost = new Post()
			{
				Id = 1,
				Title = "First post",
				Content = "First post content"
			};

			SecondPost = new Post()
			{
				Id = 2,
				Title = "Second post",
				Content = "Second post content"
			};

			ThirdPost = new Post()
			{
				Id = 3,
				Title = "Third post",
				Content = "Third post content"
			};
		}
	}
}
