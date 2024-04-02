int n = int.Parse(Console.ReadLine());

int sum1 = 0;
int sum2 = 0;
int maxDiff = 0;

for (int i = 0; i < n; i++)
{
    int num1 = int.Parse(Console.ReadLine());
    int num2 = int.Parse(Console.ReadLine());

    int currentSum = num1 + num2;

    if (i > 0)
    {
      int diff = Math.Abs(currentSum - (sum1 + sum2));
          if (diff > maxDiff)
          {
              maxDiff = diff;
          }
    }

    sum1 = num1;
    sum2 = num2;
}

if (maxDiff == 0)
{
    Console.WriteLine($"Yes, value={sum1 + sum2}");
}
else
{
    Console.WriteLine($"No, maxdiff={maxDiff}");
}
    

