double hallRent = double.Parse(Console.ReadLine());

double priceForCake = hallRent * 0.2;
double priceForDrinks = priceForCake - (priceForCake * 0.45);
double priceForAnimator = hallRent * 1 / 3;

Console.WriteLine($"{hallRent + priceForCake + priceForDrinks + priceForAnimator}");