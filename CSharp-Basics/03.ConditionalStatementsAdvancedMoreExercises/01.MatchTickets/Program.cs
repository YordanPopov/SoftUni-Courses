//Input
using System.Transactions;

double budget = double.Parse(Console.ReadLine());
string category = Console.ReadLine();
int countOfPeople = int.Parse(Console.ReadLine());

//Calculations
double priceForTicket = 0;
double budgetForTransport = 0;

switch (category)
{
	case "VIP": priceForTicket = 499.99; break;
	case "Normal": priceForTicket = 249.99; break;
	default:
		break;
}

if (countOfPeople >= 1 && countOfPeople <= 4)
{
	budgetForTransport = budget * 0.75;
}else if (countOfPeople >= 5 && countOfPeople <= 9)
{
	budgetForTransport = budget * 0.6;
}else if (countOfPeople >= 10 && countOfPeople <= 24)
{
	budgetForTransport = budget * 0.5;
}else if (countOfPeople >= 25 && countOfPeople <= 49)
{
	budgetForTransport = budget * 0.4;
}else if (countOfPeople >= 50)
{
	budgetForTransport = budget * 0.25;
}

double finalPrice = (priceForTicket * countOfPeople) + budgetForTransport;
double leftMoney = budget - finalPrice;
double neededMoney = finalPrice - budget;

//Output
if (budget >= finalPrice)
{
    Console.WriteLine($"Yes! You have {leftMoney:f2} leva left.");
}
else
{
    Console.WriteLine($"Not enough money! You need {neededMoney:f2} leva.");
}
