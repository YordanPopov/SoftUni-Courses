double strawberryPrice = double.Parse(Console.ReadLine());
double bananasKg = double.Parse(Console.ReadLine());
double orangesKg = double.Parse(Console.ReadLine());
double raspberryKg = double.Parse(Console.ReadLine());
double strawberryKg = double.Parse(Console.ReadLine());

double raspberryPrice = strawberryPrice * 0.5;
double orangePrice = raspberryPrice * 0.6;
double bananasPrice = raspberryPrice * 0.2;

double totalSum = (strawberryPrice * strawberryKg) + (bananasPrice * bananasKg) + (orangePrice * orangesKg) + (raspberryPrice * raspberryKg);
Console.WriteLine($"{totalSum:f2}");