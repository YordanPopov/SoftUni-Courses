int timeForPhotos = int.Parse(Console.ReadLine());
int numberOfScenes = int.Parse(Console.ReadLine());
int timeOfScene = int.Parse(Console.ReadLine());

double timeForPreparation = (timeForPhotos * 0.15);
int totalTimeForScenes = numberOfScenes * timeOfScene;
double totalTime = totalTimeForScenes + timeForPreparation;


if (totalTime <= timeForPhotos)
{
    Console.WriteLine($"You managed to finish the movie on time! You have {Math.Round(timeForPhotos - totalTime)} minutes left!"); 
}
else
{
    Console.WriteLine($"Time is up! To complete the movie you need {Math.Round(totalTime - timeForPhotos)} minutes.");
}



