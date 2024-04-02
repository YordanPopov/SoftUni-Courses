string nameOfSerial = Console.ReadLine();
int seasons = int.Parse(Console.ReadLine());    
int episodes = int.Parse(Console.ReadLine());
double timeOfNormalEpisod = double.Parse(Console.ReadLine());

double advertisement = timeOfNormalEpisod * 0.2;
double timeOfEpisodes = timeOfNormalEpisod + advertisement;


double totalTimeForWatching = (seasons * 10) + seasons * (episodes * timeOfEpisodes);

Console.WriteLine($"Total time needed to watch the {nameOfSerial} series is {Math.Floor(totalTimeForWatching)} minutes.");