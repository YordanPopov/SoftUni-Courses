
string fuel = Console.ReadLine();
double liters = double.Parse(Console.ReadLine());

if (liters >= 25)
{
    if (fuel == "Diesel")
    {
        Console.WriteLine($"You have enough {fuel.ToLower()}.");
    }else if (fuel == "Gasoline")
    {
        Console.WriteLine($"You have enough {fuel.ToLower()}.");
    }else if(fuel == "Gas")
    {
        Console.WriteLine($"You have enough {fuel.ToLower()}.");
    }
    else
    {
        Console.WriteLine("Invalid fuel!");
    }
}
else
{
    if(fuel == "Diesel")
    {
        Console.WriteLine($"Fill your tank with {fuel.ToLower()}!");
    }else if(fuel == "Gasoline")
    {
        Console.WriteLine($"Fill your tank with {fuel.ToLower()}!");
    }
    else if(fuel == "Gas")
    {
        Console.WriteLine($"Fill your tank with {fuel.ToLower()}!");
    }
    else
    {
        Console.WriteLine("Invalid fuel!");
    }
}