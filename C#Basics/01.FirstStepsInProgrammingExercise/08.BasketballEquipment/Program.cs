//input
int feePerYear = int.Parse(Console.ReadLine());

//calculation
double pricePerShoes = feePerYear - (0.4 * feePerYear);
double pricePerЕquipment = pricePerShoes - (0.2 * pricePerShoes);
double pricePerBall = 0.25 * pricePerЕquipment;
double pricePeрАccessories = 0.20 * pricePerBall;
double totalPrice = pricePerShoes + pricePerЕquipment + pricePerBall + pricePeрАccessories + feePerYear;

//output
Console.WriteLine(totalPrice);