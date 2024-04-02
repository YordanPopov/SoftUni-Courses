double neededMoney = double.Parse(Console.ReadLine());
double ownedMoney = double.Parse(Console.ReadLine());

int spendingCounter = 0;
int dayCounter = 0;

while (ownedMoney < neededMoney && spendingCounter < 5)
{
    string action = Console.ReadLine();
    double money = double.Parse(Console.ReadLine());
    dayCounter++;

    if (action == "spend")
    {
        ownedMoney -= money;
        spendingCounter++;
        if (ownedMoney < 0)
        {
            ownedMoney = 0;
        }

    }
    else if (action == "save")
    {
        ownedMoney += money;
        spendingCounter = 0;
    }
}
if (spendingCounter == 5)
{
    Console.WriteLine("You can't save the money.");
    Console.WriteLine(dayCounter);
}
if (ownedMoney >= neededMoney)
{
    Console.WriteLine($"You saved the money for {dayCounter} days.");
}