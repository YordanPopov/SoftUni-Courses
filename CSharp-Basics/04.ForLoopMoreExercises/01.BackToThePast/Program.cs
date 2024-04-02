double money = double.Parse(Console.ReadLine());    
int yearToLive = int.Parse(Console.ReadLine());

int age = 18;
double finalsum = money;

for (int i = 1800; i <= yearToLive; i++)
{
    if (i % 2 == 0)
    {
        finalsum -= 12_000;
    }
    else
    {
        finalsum -= (12_000 + (50 * age));
    }
    age++;
}
if (finalsum < 0)
{
    Console.WriteLine($"He will need {Math.Abs(finalsum):f2} dollars to survive.");
   
}
else
{
    Console.WriteLine($"Yes! He will live a carefree life and will have {finalsum:f2} dollars left.");
}