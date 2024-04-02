//Input
double recordTimeInSeconds = double.Parse(Console.ReadLine());
double distanceInMeters = double.Parse(Console.ReadLine());
double secondsForOneMetersOfSwimming = double.Parse(Console.ReadLine());

//Calculation
double secondsNeededForWholeDistance = distanceInMeters * secondsForOneMetersOfSwimming;
double timesSlowedDown = Math.Floor(distanceInMeters / 15);
secondsNeededForWholeDistance += timesSlowedDown * 12.5;

//Output
if (secondsNeededForWholeDistance < recordTimeInSeconds)
{
    Console.WriteLine($" Yes, he succeeded! The new world record is {secondsNeededForWholeDistance:f2} seconds.");
}
else
{
    Console.WriteLine($"No, he failed! He was {secondsNeededForWholeDistance - recordTimeInSeconds:f2} seconds slower.");
}