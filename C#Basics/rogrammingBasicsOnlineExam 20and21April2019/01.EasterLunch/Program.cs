int numberEasterBread = int.Parse(Console.ReadLine());
int numberEggShell = int.Parse(Console.ReadLine());
int cookiesKg = int.Parse(Console.ReadLine());

double totalPrice = (numberEasterBread * 3.20) + (cookiesKg * 5.40) + (numberEggShell * 4.35) + (numberEggShell * 12 * 0.15);
Console.WriteLine($"{totalPrice:f2}");