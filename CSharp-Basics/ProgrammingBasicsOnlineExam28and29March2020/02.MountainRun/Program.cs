double recordInSeconds = double.Parse(Console.ReadLine());
double destinationInMeters = double.Parse(Console.ReadLine());
double timeForClimbOneMeter = double.Parse(Console.ReadLine());

double totalTimeWithoutDelay = destinationInMeters * timeForClimbOneMeter;
double totalTimeWithDelay = (Math.Floor((destinationInMeters / 50)) * 30);
double totalTime = totalTimeWithDelay + totalTimeWithoutDelay;

if (totalTime >= recordInSeconds)
{
    Console.WriteLine($"No! He was {totalTime - recordInSeconds:f2} seconds slower.");
}
else
{
    Console.WriteLine($" Yes! The new record is {totalTime:f2} seconds.");
}