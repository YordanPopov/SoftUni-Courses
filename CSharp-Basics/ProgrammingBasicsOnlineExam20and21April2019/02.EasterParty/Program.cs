int guest = int.Parse(Console.ReadLine());  
double priceForOnePerson = double.Parse(Console.ReadLine());
double budget = double.Parse(Console.ReadLine());

double cakePrice = budget * 0.1;

if (guest >= 10 && guest <= 15)
{
    priceForOnePerson *= 0.85;
}else if (guest > 15 && guest <= 20)
{
    priceForOnePerson *= 0.8;
}else if (guest > 20)
{
    priceForOnePerson *= 0.75;
}
double totalSum = guest * priceForOnePerson + cakePrice;

if (budget >= totalSum)
{
    Console.WriteLine($"It is party time! {budget - totalSum:f2} leva left.");
}
else
{
    Console.WriteLine($"No party! {totalSum - budget:f2} leva needed.");
}