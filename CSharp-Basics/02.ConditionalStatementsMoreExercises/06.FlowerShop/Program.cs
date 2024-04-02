//Input
int countMagnolias = int.Parse(Console.ReadLine());
int countHyacinth = int.Parse(Console.ReadLine());
int countRose = int.Parse(Console.ReadLine());
int countCactus = int.Parse(Console.ReadLine());
double giftRate = double.Parse(Console.ReadLine());

//Calculation
double totalPrice = (countMagnolias * 3.25) + (countHyacinth * 4) + (countRose * 3.50) + (countCactus * 8);
double finalPrice = totalPrice * 0.95;

//Output
if (finalPrice >= giftRate)
{
    Console.WriteLine($"She is left with {Math.Floor(finalPrice - giftRate)} leva.");
}
else
{
    Console.WriteLine($"She will have to borrow {Math.Ceiling(giftRate - finalPrice)} leva.");
}
