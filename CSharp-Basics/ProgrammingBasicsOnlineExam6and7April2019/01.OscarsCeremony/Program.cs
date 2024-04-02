double hallRent = double.Parse(Console.ReadLine());

double statuettePrice = hallRent * 0.7;
double cateringPrice = statuettePrice * 0.85;
double soundPrice = cateringPrice * 0.5;
double totalPrice = hallRent + statuettePrice + soundPrice + cateringPrice;
Console.WriteLine($"{totalPrice:f2}");