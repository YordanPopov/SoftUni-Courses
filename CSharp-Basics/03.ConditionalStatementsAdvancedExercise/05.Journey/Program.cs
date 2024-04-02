//Input
double budget = double.Parse(Console.ReadLine());  
string season = Console.ReadLine();

//Calculations
string destination = "";
string vacationType = "";
double spentMoney = 0;

if (budget <= 100)
{
    destination = "Bulgaria";
    if (season == "summer")
    {
        spentMoney = budget * 0.3;
        vacationType = "Camp"; 
    }
    else if (season == "winter")
    {
        spentMoney = budget * 0.7;
        vacationType = "Hotel";
    }
}
else if (budget > 100 && budget <= 1000)
{
    destination = "Balkans";
    if (season == "summer")
    {
        spentMoney = budget * 0.4;
        vacationType = "Camp";
    }else if (season == "winter")
    {
        spentMoney = budget * 0.8;
        vacationType = "Hotel";
    }
}
else if (budget > 1000)
{
    destination = "Europe";
    vacationType = "Hotel";
    spentMoney = budget * 0.9;
}
//Output
Console.WriteLine($"Somewhere in {destination}");
Console.WriteLine($"{vacationType} - {spentMoney:f2}");