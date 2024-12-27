using System.ComponentModel.DataAnnotations;
using static ForumApp.Data.DataConstants;

namespace ForumApp.Models.Post
{
	public class PostFormModel
	{
		[Required]
		[StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
		public string Title { get; set; } 

		[Required]
		[StringLength(ContentMaxLength, MinimumLength = ContentMinLength)]
		public string Content { get; set; }
	}
}
