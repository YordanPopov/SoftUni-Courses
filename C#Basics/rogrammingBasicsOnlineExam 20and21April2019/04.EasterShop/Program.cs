int countOfEggs = int.Parse(Console.ReadLine());

bool isEmpty = false;
int soldEgs = 0;
string command = Console.ReadLine();
while (command != "Close")
{
    int eggsToBuyOrFill = int.Parse(Console.ReadLine());
    if (command == "Buy")
    {
        if (eggsToBuyOrFill > countOfEggs)
        {
            isEmpty = true;
            break;
        }
        else
        {
            countOfEggs -= eggsToBuyOrFill;
            soldEgs += eggsToBuyOrFill;
        }
    }
    else if (command == "Fill")
    {
        countOfEggs += eggsToBuyOrFill;
    }
    command = Console.ReadLine();
}
if (!isEmpty)
{
    Console.WriteLine("Store is closed!");
    Console.WriteLine($"{soldEgs} eggs sold.");
}
else
{
    Console.WriteLine($"Not enough eggs in store!");
    Console.WriteLine($"You can buy only {countOfEggs}.");
}