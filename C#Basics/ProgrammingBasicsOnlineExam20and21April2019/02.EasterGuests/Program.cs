int guests = int.Parse(Console.ReadLine());
double budget = double.Parse(Console.ReadLine());

double numberEasterBread = Math.Ceiling(guests / 3.0);
double numberEggs = guests * 2;

double totalPrice = (numberEasterBread * 4) + (numberEggs * 0.45);

if (budget >= totalPrice)
{
    Console.WriteLine($"Lyubo bought {numberEasterBread} Easter bread and {numberEggs} eggs.");
    Console.WriteLine($"He has {budget - totalPrice:f2} lv. left.");
}
else
{
    Console.WriteLine("Lyubo doesn't have enough money.");
    Console.WriteLine($"He needs {totalPrice - budget:f2} lv. more.");
}