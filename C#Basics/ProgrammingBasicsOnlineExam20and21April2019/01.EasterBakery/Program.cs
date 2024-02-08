double flourPrice = double.Parse(Console.ReadLine());
double flourKg = double.Parse(Console.ReadLine());  
double sugarKg = double.Parse(Console.ReadLine());
int numberEggShell = int.Parse(Console.ReadLine());
int yeastPakeckets = int.Parse(Console.ReadLine());

double sugarPrice = flourPrice * 0.75;
double priceEggShell = flourPrice * 1.1;
double yeastPrice = sugarPrice * 0.2;

double totalPrice = (flourPrice * flourKg) + (sugarPrice * sugarKg) + (numberEggShell * priceEggShell) + (yeastPakeckets * yeastPrice);
Console.WriteLine($"{totalPrice:f2}");