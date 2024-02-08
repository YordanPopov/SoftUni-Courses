double desireProfit = double.Parse(Console.ReadLine());

double sumOfOrders = 0.0;
bool isAcquired = false;
string coctailName = Console.ReadLine();

while (coctailName != "Party!")
{
    int numberOfCoctails = int.Parse(Console.ReadLine());
    double coctailPrice = coctailName.Length;
    double orderPrice = coctailPrice * numberOfCoctails;
    if (orderPrice % 2 != 0)
    {
        orderPrice *= 0.75;
    }
    sumOfOrders += orderPrice;
    if (sumOfOrders >= desireProfit)
    {
        isAcquired = true;
        break;
    }
    coctailName = Console.ReadLine();
}

if (isAcquired)
{
    Console.WriteLine("Target acquired.");
    Console.WriteLine($"Club income - {sumOfOrders:f2} leva.");
}
else
{
    double neededMoney = desireProfit - sumOfOrders;
    Console.WriteLine($"We need {neededMoney:f2} leva more.");
    Console.WriteLine($"Club income - {sumOfOrders:f2} leva.");
}
