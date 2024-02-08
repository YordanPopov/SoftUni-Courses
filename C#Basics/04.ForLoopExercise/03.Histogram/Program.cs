int n = int.Parse(Console.ReadLine());

int counterP1 = 0;
int counterP2 = 0;
int counterP3 = 0;
int counterP4 = 0;
int counterP5 = 0;

for (int i = 0; i < n ; i++)
{
    int number = int.Parse(Console.ReadLine());
    if (number < 200)
    {
        counterP1++;
    }else if (number >= 200 && number <= 399)
    {
        counterP2++;
    }else if (number > 399 && number <= 599)
    {
        counterP3++;
    }else if (number > 599 && number <= 799)
    {
        counterP4++;
    }else if (number > 799)
    {
        counterP5++;
    }
}

double p1 = counterP1 * 100.0 / n;
double p2 = counterP2 * 100.0 / n;
double p3 = counterP3 * 100.0 / n;
double p4 = counterP4 * 100.0 / n;
double p5 = counterP5 * 100.0 / n;

Console.WriteLine($"{p1:f2}%");
Console.WriteLine($"{p2:f2}%");
Console.WriteLine($"{p3:f2}%");
Console.WriteLine($"{p4:f2}%");
Console.WriteLine($"{p5:f2}%");