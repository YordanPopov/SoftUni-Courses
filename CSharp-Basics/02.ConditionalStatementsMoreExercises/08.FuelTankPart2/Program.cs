//Input
string fuel = Console.ReadLine();
double amountOfFuel = double.Parse(Console.ReadLine());
string clubCard = Console.ReadLine();
double fuelPrice;

if (amountOfFuel > 1.00 && amountOfFuel <= 50.00)
{
    if (fuel == "Gas")
    {
        fuelPrice = amountOfFuel * 0.93;
        if (clubCard == "Yes")
        {
            fuelPrice = amountOfFuel * (0.93 - 0.08);
        }
        else if (clubCard == "No")
        {
            fuelPrice = fuelPrice;
        }
        if (amountOfFuel >= 20 && amountOfFuel <= 25)
        {
            fuelPrice *= 0.92;
        }
        else if (amountOfFuel > 25)
        {
            fuelPrice *= 0.90;
        }
        Console.WriteLine($"{fuelPrice:f2} lv.");
    }
    else if (fuel == "Gasoline")
    {
        fuelPrice = amountOfFuel * 2.22;
        if (clubCard == "Yes")
        {
            fuelPrice = amountOfFuel * (2.22 - 0.18);
        }
        else if (clubCard == "No")
        {
            fuelPrice = fuelPrice;
        }
        if (amountOfFuel >= 20 && amountOfFuel <= 25)
        {
            fuelPrice *= 0.92;
        }
        else if (amountOfFuel > 25)
        {
            fuelPrice *= 0.90;
        }
        Console.WriteLine($"{fuelPrice:f2} lv.");
    }
    else if (fuel == "Diesel")
    {
        fuelPrice = amountOfFuel * 2.33;
        if (clubCard == "Yes")
        {
            fuelPrice = amountOfFuel * (2.33 - 0.12);
        }
        else if (clubCard == "No")
        {
            fuelPrice = fuelPrice;
        }
        if (amountOfFuel >= 20 && amountOfFuel <= 25)
        {
            fuelPrice *= 0.92;
        }
        else if (amountOfFuel > 25)
        {
            fuelPrice *= 0.90;
        }
        Console.WriteLine($"{fuelPrice:f2} lv.");
    }
}