double feePerYear = double.Parse(Console.ReadLine());

double priceForShoes = feePerYear * 0.6;
double priceForЕquipment = priceForShoes * 0.8;
double priceForBall = priceForЕquipment * 0.25;
double accessories = priceForBall * 0.2;
double totalSum = feePerYear + priceForBall + priceForShoes + priceForЕquipment + accessories;
Console.WriteLine($"{totalSum:f2}");