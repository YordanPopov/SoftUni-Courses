//Input
string season = Console.ReadLine();
double kilometersPerMonth = double.Parse(Console.ReadLine());

//Calculations
double pricePerKilometers = 0;
double totalPrice = 0;

if (season == "Spring" || season == "Autumn")
{
    if (kilometersPerMonth <= 5000)
    {
        pricePerKilometers = 0.75;
    }
    else if (kilometersPerMonth > 5000 && kilometersPerMonth <= 10_000)
    {
        pricePerKilometers = 0.95;
    }
    else if (kilometersPerMonth > 10_000 && kilometersPerMonth <= 20_000)
    {
        pricePerKilometers = 1.45;
    }
}
else if (season == "Summer")
{
    if (kilometersPerMonth <= 5000)
    {
        pricePerKilometers = 0.9;
    }
    else if (kilometersPerMonth > 5000 && kilometersPerMonth <= 10_000)
    {
        pricePerKilometers = 1.1;
    }
    else if (kilometersPerMonth > 10_000 && kilometersPerMonth <= 20_000)
    {
        pricePerKilometers = 1.45;
    }
}
else if (season == "Winter")
{
    if (kilometersPerMonth <= 5000)
    {
        pricePerKilometers = 1.05;
    }
    else if (kilometersPerMonth > 5000 && kilometersPerMonth <= 10_000)
    {
        pricePerKilometers = 1.25;
    }
    else if (kilometersPerMonth> 10000 && kilometersPerMonth <= 20_000)
    {
        pricePerKilometers = 1.45;
    }
}
totalPrice = ((pricePerKilometers * kilometersPerMonth) * 4) * 0.9;

//Output
Console.WriteLine($"{totalPrice:f2}");