string drink = Console.ReadLine();
string sugar = Console.ReadLine();
int countOfDrinks = int.Parse(Console.ReadLine());

double priceForDrink = 0;

if (drink == "Espresso")
{
    if (sugar == "Without")
    {
        priceForDrink = 0.90;

    }else if(sugar == "Normal")
    {
        priceForDrink = 1;

    }else if (sugar == "Extra")
    {
        priceForDrink = 1.20;
    }
}
else if (drink == "Cappuccino")
{
    if (sugar == "Without")
    {
        priceForDrink = 1;
    }
    else if (sugar == "Normal")
    {
        priceForDrink = 1.20;
    }
    else if (sugar == "Extra")
    {
        priceForDrink = 1.60;
    }
}
else if (drink == "Tea")
{
    if (sugar == "Without")
    {
        priceForDrink = 0.5;
    }
    else if (sugar == "Normal")
    {
        priceForDrink = 0.6;
    }
    else if (sugar == "Extra")
    {
        priceForDrink = 0.7;
    }
}

double totalPrice = priceForDrink * countOfDrinks;

if (sugar == "Without")
{
    totalPrice *= 0.65;
}
if (drink == "Espresso" && countOfDrinks >= 5)
{
    totalPrice *= 0.75;
}
if (totalPrice > 15)
{
    totalPrice *= 0.80;
}

Console.WriteLine($"You bought {countOfDrinks} cups of {drink} for {totalPrice:f2} lv.");