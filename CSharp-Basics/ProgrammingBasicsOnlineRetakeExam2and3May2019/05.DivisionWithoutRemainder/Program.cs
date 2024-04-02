int numbers = int.Parse(Console.ReadLine());

int p2 = 0;
int p3 = 0;
int p4 = 0;
for (int number = 0; number < numbers; number++)
{
    int currentNumber = int.Parse(Console.ReadLine());
    if (currentNumber % 2 == 0)
    {
        p2++;
    }
    if (currentNumber % 3 == 0)
    {
        p3++;
    }
    if (currentNumber % 4 == 0)
    {
        p4++;
    }
}

Console.WriteLine($"{(double)p2 / numbers * 100:f2}%");
Console.WriteLine($"{(double)p3 / numbers * 100:f2}%");
Console.WriteLine($"{(double)p4 / numbers * 100:f2}%");