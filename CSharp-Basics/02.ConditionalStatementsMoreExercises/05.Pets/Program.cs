//Input
int numberOfDays = int.Parse(Console.ReadLine());   
int availableFood = int.Parse(Console.ReadLine());
double foodForDogInKilograms = double.Parse(Console.ReadLine());
double foodForCatInKilograms = double.Parse(Console.ReadLine());
double foodForTurtleInGrams = double.Parse(Console.ReadLine()) / 1000;

//Calculations
double foodForEat = (foodForCatInKilograms * numberOfDays) + (foodForTurtleInGrams * numberOfDays) + (foodForDogInKilograms * numberOfDays);

if (availableFood >= foodForEat )
{
    Console.WriteLine($"{Math.Floor(availableFood - foodForEat)} kilos of food left.");
}
else
{
    Console.WriteLine($"{Math.Ceiling(foodForEat - availableFood)} more kilos of food are needed.");
}