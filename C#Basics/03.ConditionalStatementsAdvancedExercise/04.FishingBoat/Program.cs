//Input
int budget = int.Parse(Console.ReadLine());
string season = Console.ReadLine();
int numberOfFishermans = int.Parse(Console.ReadLine());

//Calculations
double priceForBoat = 0;
double priceWithDiscount = 0;
double finalPrice = 0;
double priceWithAdditionalDiscount = 0;

if (season == "Spring")
{
    priceForBoat = 3000;
    if (numberOfFishermans >= 1 && numberOfFishermans <= 6)
    {
        priceWithDiscount = priceForBoat - (priceForBoat * 0.1);
        finalPrice = priceWithDiscount;
    }else if(numberOfFishermans >= 7 && numberOfFishermans <= 11)
    {
        priceWithDiscount = priceForBoat - (priceForBoat * 0.15);
        finalPrice = priceWithDiscount;
    }else if(numberOfFishermans > 12)
    {
        priceWithDiscount = priceForBoat - (priceForBoat * 0.25);
        finalPrice = priceWithDiscount;
    }
    else
    {
        finalPrice = priceForBoat;
    }
}
else if (season == "Summer" || season == "Autumn")
{
    priceForBoat = 4200;
    if (numberOfFishermans >= 1 && numberOfFishermans <= 6)
    {
        priceWithDiscount = priceForBoat - (priceForBoat * 0.1);
        finalPrice = priceWithDiscount;
    }
    else if (numberOfFishermans >= 7 && numberOfFishermans <= 11)
    {
        priceWithDiscount = priceForBoat - (priceForBoat * 0.15);
        finalPrice = priceWithDiscount;
    }
    else if (numberOfFishermans > 12)
    {
        priceWithDiscount = priceForBoat - (priceForBoat * 0.25);
        finalPrice = priceWithDiscount;
    }
    else
    {
        finalPrice = priceForBoat;
    }
}
else if (season == "Winter")
{
    priceForBoat = 2600;
    if (numberOfFishermans >= 1 && numberOfFishermans <= 6)
    {
        priceWithDiscount = priceForBoat - (priceForBoat * 0.1);
        finalPrice = priceWithDiscount;
    }
    else if (numberOfFishermans >= 7 && numberOfFishermans <= 11)
    {
        priceWithDiscount = priceForBoat - (priceForBoat * 0.15);
        finalPrice = priceWithDiscount;
    }
    else if (numberOfFishermans > 12)
    {
        priceWithDiscount = priceForBoat - (priceForBoat * 0.25);
        finalPrice = priceWithDiscount;
    }
    else
    {
        finalPrice = priceForBoat;
    }
}
if (numberOfFishermans % 2 == 0 && season != "Autumn")
{
    priceWithAdditionalDiscount = finalPrice - (finalPrice * 0.05);
}
else
{
    priceWithAdditionalDiscount = finalPrice;
}

if (budget >= priceWithAdditionalDiscount)
{
    double leftMoney = budget - priceWithAdditionalDiscount;
    Console.WriteLine($"Yes! You have {leftMoney:f2} leva left.");
}
else
{
    double neededMoney = priceWithAdditionalDiscount - budget;
    Console.WriteLine($"Not enough money! You need {neededMoney:f2} leva.");
}
