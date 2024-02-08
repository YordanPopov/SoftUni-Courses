//Input
int restDays  = int.Parse(Console.ReadLine());

//Calculations
int year = 365;
int worksDays = year - restDays;
int totalPlayWithTom = (restDays * 127) + (worksDays * 63);

//Output
if (totalPlayWithTom <= 30000)
{
    int leftTIme = 30000 - totalPlayWithTom;
    int hours = leftTIme / 60;
    int minutes = leftTIme % 60;
    Console.WriteLine("Tom sleeps well");
    Console.WriteLine($"{hours} hours and {minutes} minutes less for play");
}
else
{
    int leftTime = totalPlayWithTom - 30000;
    int hours = leftTime / 60;
    int minutes = leftTime % 60;
    Console.WriteLine("Tom will run away");
    Console.WriteLine($"{hours} hours and {minutes} minutes more for play");
}

