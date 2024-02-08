//Input
double budget = double.Parse(Console.ReadLine());
string season = Console.ReadLine();

//Calculations
string location = "";
string place = "";
double priceForVacation = 0;

if (budget <= 1000)
{
    place = "Camp";
    if (season == "Summer")
    {
        location = "Alaska";
        priceForVacation = budget * 0.65;
    }
    else if (season == "Winter")
    {
        location = "Morocco";
        priceForVacation = budget * 0.45;
    }
}
else if (budget > 1000 && budget <= 3000 )
{
    place = "Hut";
    if (season == "Summer")
    {
        location = "Alaska";
        priceForVacation = budget * 0.8;
    }else if (season == "Winter")
    {
        location = "Morocco";
        priceForVacation = budget * 0.60;
    }
}
else if (budget > 3000)
{
    place = "Hotel";
    if (season == "Summer")
    {
        location = "Alaska";
        priceForVacation = budget * 0.9;
    }else if (season == "Winter")
    {
        location = "Morocco";
        priceForVacation = budget * 0.9;
    }
}

//Output
Console.WriteLine($"{location} - {place} - {priceForVacation:f2}");