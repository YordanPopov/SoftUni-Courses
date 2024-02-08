double budget = double.Parse(Console.ReadLine());   
int statistics = int.Parse(Console.ReadLine()); 
double clothesPrice = double.Parse(Console.ReadLine());

double decorPrice = budget * 0.1;
if (statistics > 150)
{
    clothesPrice *= 0.9;
}

double totalPrice = decorPrice + (statistics * clothesPrice);
if (budget >= totalPrice)
{
    Console.WriteLine("Action!");
    Console.WriteLine($"Wingard starts filming with {budget - totalPrice:f2} leva left.");
}else
{
    Console.WriteLine("Not enough money!");
    Console.WriteLine($"Wingard needs {totalPrice - budget:f2} leva more.");
}