namespace _01.Songs
{
    public class Program
    {
        public class Song
        {
            public string TypeList { get; set; }

            public string Name { get; set; }

            public string Time { get; set; }

            public Song(string typeList, string name, string time)
            {
                TypeList = typeList;
                Name = name;
                Time = time;
            }
        }

        static void Main(string[] args)
        {
            List<Song> songs = new();

            int songCount = int.Parse(Console.ReadLine());

            for (int i = 1; i <= songCount; i++)
            {
                string[] input = Console.ReadLine().Split("_");
                string typeList = input[0];
                string name = input[1];
                string time = input[2];

                Song currentSong = new Song(typeList, name, time);
                songs.Add(currentSong);
            }

            string command = Console.ReadLine();

            if (command == "all")
            {
                foreach (Song song in songs)
                {
                    Console.WriteLine(song.Name);
                }
            }
            else
            {
                List<Song> filteredSongs = songs.Where(s => s.TypeList == command).ToList();

                foreach (Song song in filteredSongs)
                {
                    Console.WriteLine(song.Name);
                }
            }
        }
    }
}