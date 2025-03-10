using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e2eTests.Data
{
	public class Album
	{
		public string Name { get; set; }

		public string ImageUrl { get; set; } = "https://www.grimmgent.com/wp-content/uploads/2022/03/news_2022-3-10_Rammstein-announce-new-album-and-share-single.jpg";

		public string Price { get; set; } = "10.99";

		public string ReleaseDate { get; set; } = "01/01/1970";

		public string Artist { get; set; } = "someArtist";

		public string Genre { get; set; } = "someGenre";

		public string Description { get; set; } = "someDescription";

		public Album(string albumName)
		{
			Name = albumName;
		}
	}
}
