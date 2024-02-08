using System.Transactions;

string country = Console.ReadLine();
string appliance = Console.ReadLine();

double performancePrice = 0.0;
double difficultyPrice = 0.0;

if (country == "Russia")
{
    if (appliance == "ribbon")
    {
        performancePrice = 9.400;
        difficultyPrice = 9.100;
    }else if (appliance == "hoop")
    {
        performancePrice = 9.800;
        difficultyPrice = 9.300;
    }else if (appliance == "rope")
    {
        performancePrice = 9.000;
        difficultyPrice = 9.600;
    }
}
else if (country == "Bulgaria")
{
    if (appliance == "ribbon")
    {
        performancePrice = 9.400;
        difficultyPrice = 9.600;
    }
    else if (appliance == "hoop")
    {
        difficultyPrice = 9.550;
        performancePrice = 9.750;
    }
    else if (appliance == "rope")
    {
        difficultyPrice = 9.500;
        performancePrice = 9.400;
    }
}
else if (country == "Italy")
{
    if (appliance == "ribbon")
    {
        difficultyPrice = 9.200;
        performancePrice = 9.500;
    }
    else if (appliance == "hoop")
    {
        difficultyPrice = 9.450;
        performancePrice = 9.350;
    }
    else if (appliance == "rope")
    {
        difficultyPrice = 9.700;
        performancePrice = 9.150;
    }
}

double rating = difficultyPrice + performancePrice;
double percentageNeededMaxRate = (20 - rating) / 20 * 100;
Console.WriteLine($"The team of {country} get {rating:f3} on {appliance}.");
Console.WriteLine($"{percentageNeededMaxRate:f2}%");