int controlMinutes = int.Parse(Console.ReadLine()); 
int controlSeconds = int.Parse(Console.ReadLine());
double length = double.Parse(Console.ReadLine());
int seconds100Meters = int.Parse(Console.ReadLine());

controlSeconds = controlSeconds + (controlMinutes * 60);
double delay = length / 120;
double totalDelay = delay * 2.5;
double time = (length / 100) * seconds100Meters - totalDelay;
if (time <= controlSeconds)
{
    Console.WriteLine($"Marin Bangiev won an Olympic quota!");
    Console.WriteLine($"His time is {time:f3}.");
}
else
{
    Console.WriteLine($"No, Marin failed! He was {time - controlSeconds:f3} second slower.");
}