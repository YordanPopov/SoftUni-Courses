//Input
int kilometers = int.Parse(Console.ReadLine());
string periodOfDay = Console.ReadLine();

//Calculations
double taxiDailyRate = 0.7 + (kilometers * 0.79);
double taxiNightRate = 0.7 + (kilometers * 0.90);
double busRate = kilometers * 0.09;
double trainRate = kilometers * 0.06;

//Output
if (kilometers < 20)
{
    if (periodOfDay == "day")
    {
        Console.WriteLine($"{taxiDailyRate:f2}");
    }else if(periodOfDay == "night")
    {
        Console.WriteLine($"{taxiNightRate:f2}");
    }
}else if ( kilometers >= 20 && kilometers < 100)
{
    Console.WriteLine($"{busRate:f2}");
}
else
{
    Console.WriteLine($"{trainRate:f2}");
}