int numberEasterBreads = int.Parse(Console.ReadLine());

double totalSugar = 0.0;
double totalFlour = 0.0;
int maxSugar = int.MinValue;
int maxFlour = int.MinValue;  

for (int bread = 1; bread <= numberEasterBreads; bread++)
{
    int sugar = int.Parse(Console.ReadLine());
    int flour = int.Parse(Console.ReadLine());
    totalSugar += sugar;
    totalFlour += flour;
    if (sugar > maxSugar)
    {
        maxSugar = sugar;
    }
    if (flour > maxFlour)
    {
        maxFlour = flour;
    }

}

double packetsSugar = Math.Ceiling(totalSugar / 950);
double packetsFlour = Math.Ceiling(totalFlour / 750);

Console.WriteLine($"Sugar: {packetsSugar}");
Console.WriteLine($"Flour: {packetsFlour}");
Console.WriteLine($"Max used flour is {maxFlour} grams, max used sugar is {maxSugar} grams.");