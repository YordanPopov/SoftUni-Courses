double budget = double.Parse(Console.ReadLine());
int nightStays = int.Parse(Console.ReadLine());
double pricePerNight = double.Parse(Console.ReadLine());
double percentageExpenses = double.Parse(Console.ReadLine()) / 100;

if (nightStays > 7)
{
    pricePerNight *= 0.95;
}

double totalSUm = nightStays * pricePerNight + (budget * percentageExpenses);

if (budget >= totalSUm)
{
    Console.WriteLine($"Ivanovi will be left with {budget - totalSUm:f2} leva after vacation.");
}
else
{
    Console.WriteLine($"{totalSUm - budget:f2} leva needed.");
}