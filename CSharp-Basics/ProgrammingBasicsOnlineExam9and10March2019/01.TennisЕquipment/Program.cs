double tennisRacketPrice = double.Parse(Console.ReadLine());
int numberOfTennisRacket = int.Parse(Console.ReadLine());
int numberOfShoes = int.Parse(Console.ReadLine());

double shoesPrice = tennisRacketPrice / 6;
double totalPriceOne = tennisRacketPrice * numberOfTennisRacket + (numberOfShoes * shoesPrice);
double totalPriceTwo = totalPriceOne * 0.2;
double totalPriceThree = totalPriceTwo + totalPriceOne;

double priceForPlayer = totalPriceThree / 8;
double priceForSponosrs = totalPriceThree * 0.875;

Console.WriteLine($"Price to be paid by Djokovic {Math.Floor(priceForPlayer)}");
Console.WriteLine($"Price to be paid by sponsors {Math.Ceiling(priceForSponosrs)}");
