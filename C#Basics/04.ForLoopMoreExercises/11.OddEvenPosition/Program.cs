int n = int.Parse(Console.ReadLine());

double sumOdd = 0;
double sumEven = 0;
double minNumberOdd = double.MaxValue;
double maxNumberOdd = double.MinValue;
double minNumberEven = double.MaxValue;
double maxNumberEven = double.MinValue;

for (int i = 1; i <= n; i++)
{
    double number = double.Parse(Console.ReadLine());
    if (i % 2 == 0)
    {
        sumEven += number;
        if (number > maxNumberEven)
        {
            maxNumberEven = number;
        }
        if (number < minNumberEven)
        {
            minNumberEven = number;
        }
    }
    else
    {
        sumOdd += number;
        if (number > maxNumberOdd)
        {
            maxNumberOdd = number;
        }
        if (number < minNumberOdd)
        {
            minNumberOdd = number;
        }
    }
}

Console.WriteLine($"OddSum={sumOdd:f2},");
if (minNumberOdd == double.MaxValue)
{
    Console.WriteLine("OddMin=No,");
}
else
{
    Console.WriteLine($"OddMin={minNumberOdd:f2},");
}
if (maxNumberOdd == double.MinValue)
{
    Console.WriteLine("OddMax=No,");
}
else
{
    Console.WriteLine($"OddMax={maxNumberOdd:f2},");
}
Console.WriteLine($"EvenSum={sumEven:f2},");
if (minNumberEven == double.MaxValue)
{
    Console.WriteLine("EvenMin=No,");
}
else
{
    Console.WriteLine($"EvenMin={minNumberEven:f2},");
}
if (maxNumberEven == double.MinValue)
{
    Console.WriteLine("EvenMax=No");
}
else
{
    Console.WriteLine($"EvenMax={maxNumberEven:f2}");
}
