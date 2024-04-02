string input = Console.ReadLine();

int maxNumber = int.MinValue;
while (input != "Stop")
{
    int currentNumber = int.Parse(input);
    if (currentNumber > maxNumber)
    {
        maxNumber = currentNumber;
    }

    input = Console.ReadLine();
}
Console.WriteLine(maxNumber);