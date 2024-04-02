int n = int.Parse(Console.ReadLine());
int maxNumber = int.MinValue;
int sum = 0;

for (int i = 1; i <= n; i++)
{
    int number = int.Parse(Console.ReadLine());
    sum += number;
    if (number > maxNumber)
    {
        maxNumber = number;
    }
}
int sumWithoutMaxNumber = sum - maxNumber;
if (maxNumber == sumWithoutMaxNumber)
{
    Console.WriteLine("Yes");
    Console.WriteLine("Sum = {0}", sumWithoutMaxNumber);
}
else
{
    Console.WriteLine("No");
    Console.WriteLine($"Diff = {Math.Abs(maxNumber - sumWithoutMaxNumber)}");
}

