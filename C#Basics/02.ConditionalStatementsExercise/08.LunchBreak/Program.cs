//Input
string serialName = Console.ReadLine();
int episodeDuration = int.Parse(Console.ReadLine());
int restDuration = int.Parse(Console.ReadLine());

//Calculations
double restForLunch = restDuration * (1 / 8.0);
double restForRelax = restDuration * (1 / 4.0);
double timeForSerial = restDuration - restForLunch - restForRelax;

//Output
if (timeForSerial >= episodeDuration)
{
    double leftTime = Math.Ceiling(timeForSerial - episodeDuration);
    Console.WriteLine($"You have enough time to watch {serialName} and left with {leftTime} minutes free time.");
}
else
{
    double neededTime = Math.Ceiling(episodeDuration - timeForSerial);
    Console.WriteLine($"You don't have enough time to watch {serialName}, you need {neededTime} more minutes.");
}
