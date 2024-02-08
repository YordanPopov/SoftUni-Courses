int n = int.Parse(Console.ReadLine());

int firstSum = 0;
int secondSum = 0;
for (int i = 0; i <= n - 1; i++)
{
    int num = int.Parse(Console.ReadLine());
    firstSum += num;
}

for (int i = 0; i <= n - 1; i++)
{
    int num = int.Parse(Console.ReadLine());
    secondSum += num;
}
if (firstSum == secondSum)
{
    Console.WriteLine($"Yes, sum = {firstSum}");
}
else
{
    Console.WriteLine($"No, diff = {Math.Abs(firstSum - secondSum)}");
}