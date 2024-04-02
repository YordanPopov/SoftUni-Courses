string input = Console.ReadLine();

double bankBalance = 0;

while (input != "NoMoreMoney")
{
    double currentSum = double.Parse(input);

    if (currentSum < 0)
    {
        Console.WriteLine("Invalid operation!");
        break;
    }

    bankBalance += currentSum;
    Console.WriteLine($"Increase: {currentSum:f2}");

    input = Console.ReadLine();
}
Console.WriteLine($"Total: {bankBalance:f2}");