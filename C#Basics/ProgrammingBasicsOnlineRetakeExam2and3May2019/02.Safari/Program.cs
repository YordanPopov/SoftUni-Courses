double budget = double.Parse(Console.ReadLine());
double fuels = double.Parse(Console.ReadLine());
string day = Console.ReadLine();

double totalSum = fuels * 2.10 + 100;

switch (day)
{
	case "Saturday": totalSum *= 0.9; break;
	case "Sunday": totalSum *= 0.8; break;
	default:
		break;
}

if (budget >= totalSum)
{
    Console.WriteLine($"Safari time! Money left: {budget - totalSum:f2} lv. ");
}
else
{
    Console.WriteLine($"Not enough money! Money needed: {totalSum - budget:f2} lv.");
}