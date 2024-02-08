//Input 
string flowers = Console.ReadLine();
int numberOfFlowers = int.Parse(Console.ReadLine());
int budget = int.Parse(Console.ReadLine());

//Calculations
double costOfRoses = 5;
double costOfDahlias = 3.80;
double costOfTulips = 2.80;
double costOfNarcissus = 3;
double costOfGladiolus = 2.50;

double totalPrice = 0;
double priceWithDiscount = 0;
double finalPrice = 0;

if (flowers == "Roses")
{
    if (numberOfFlowers > 80)
    {
        totalPrice = costOfRoses * numberOfFlowers;
        priceWithDiscount = totalPrice - (totalPrice * 0.1);
        finalPrice = priceWithDiscount;
    }
    else
    {
        finalPrice = costOfRoses * numberOfFlowers;
    }
}
if (flowers == "Dahlias")
{
    if (numberOfFlowers > 90)
    {
        totalPrice = costOfDahlias * numberOfFlowers;
        priceWithDiscount = totalPrice - (totalPrice * 0.15);
        finalPrice = priceWithDiscount;
    }
    else
    {
        finalPrice = costOfDahlias * numberOfFlowers;
    }
}
if (flowers == "Tulips")
{
    if (numberOfFlowers > 80)
    {
        totalPrice = costOfTulips * numberOfFlowers;
        priceWithDiscount = totalPrice - (totalPrice * 0.15);
        finalPrice = priceWithDiscount;
    }
    else
    {
        finalPrice = costOfTulips * numberOfFlowers;
    }
}
if (flowers == "Narcissus")
{
    if(numberOfFlowers < 120)
    {
        totalPrice = costOfNarcissus * numberOfFlowers;
        priceWithDiscount = totalPrice + (totalPrice * 0.15);
        finalPrice = priceWithDiscount;
    }
    else
    {
        finalPrice = costOfNarcissus * numberOfFlowers;
    }
}
if (flowers == "Gladiolus")
{
    if (numberOfFlowers < 80)
    {
        totalPrice = costOfGladiolus * numberOfFlowers;
        priceWithDiscount = totalPrice + (totalPrice * 0.20);
        finalPrice = priceWithDiscount;
    }
    else
    {
        finalPrice = costOfGladiolus * numberOfFlowers;
    }
}
double leftMoney = budget - finalPrice;
double neededMoney = finalPrice - budget;

//Output
if (budget >= finalPrice)
{
    Console.WriteLine($"Hey, you have a great garden with {numberOfFlowers} {flowers} and {leftMoney:f2} leva left.");
}
else
{
    Console.WriteLine($"Not enough money, you need {neededMoney:f2} leva more.");
}