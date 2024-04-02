//Input
int metersVineyard = int.Parse(Console.ReadLine());
double grapesPerMeter = double.Parse(Console.ReadLine());
int neededLitersWine = int.Parse(Console.ReadLine());
int countWorkers = int.Parse(Console.ReadLine());

//Calculation
double totalKilosGrapes = metersVineyard * grapesPerMeter;
double grapesForWine = (totalKilosGrapes * 0.4) / 2.5;

if (grapesForWine >= neededLitersWine)
{
    double leftLiters = grapesForWine - neededLitersWine;
    double litersPerPerson =Math.Ceiling(leftLiters / countWorkers);
    Console.WriteLine($"Good harvest this year! Total wine: {Math.Floor(grapesForWine)} liters.");
    Console.WriteLine($"{leftLiters} liters left -> {litersPerPerson} liters per person.");
}
else
{
    double neededLiters = Math.Floor(neededLitersWine - grapesForWine);
    Console.WriteLine($"It will be a tough winter! More {neededLiters} liters wine needed.");
}