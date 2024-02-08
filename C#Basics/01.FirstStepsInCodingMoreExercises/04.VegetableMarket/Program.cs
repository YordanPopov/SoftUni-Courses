//input
double pricePerKilogramVegetables = double.Parse(Console.ReadLine());
double pricePerKilogramFruits = double.Parse(Console.ReadLine());
double totalKilosVegetables = double.Parse(Console.ReadLine());
double toralKilosFruits = double.Parse(Console.ReadLine());

//calculation
double totalPriceBgn = (totalKilosVegetables * pricePerKilogramVegetables) + (toralKilosFruits * pricePerKilogramFruits);
double totalPriceEur = totalPriceBgn / 1.940;
string formattedTotalPriceEur = totalPriceEur.ToString("0.00");

//output
Console.WriteLine(formattedTotalPriceEur);