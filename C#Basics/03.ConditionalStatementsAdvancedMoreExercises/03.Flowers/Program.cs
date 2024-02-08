//Input
int countOfChrys = int.Parse(Console.ReadLine());
int countOfRoses = int.Parse(Console.ReadLine());
int countOfTulips = int.Parse(Console.ReadLine());
string season = Console.ReadLine();
string typeOfDay = Console.ReadLine();

//Calculations
double priceForChrys = 0;
double priceForRoses = 0;
double priceForTulips = 0;
int sumOfFlowers = countOfChrys + countOfRoses + countOfTulips;

switch (season)
{
	case "Spring":
	case "Summer":
		priceForChrys = 2.00;
		priceForRoses = 4.10;
		priceForTulips = 2.50;
		break;
	case "Autumn":
	case "Winter":
		priceForChrys = 3.75;
		priceForRoses = 4.50;
		priceForTulips = 4.15;
		break;
	default:
		break;
}

double totalPrice = (countOfChrys * priceForChrys) + (countOfRoses * priceForRoses) + (countOfTulips * priceForTulips);

if (typeOfDay == "Y")
{
	totalPrice *= 1.15;
}
if (countOfTulips > 7 && season == "Spring")
{
	totalPrice *= 0.95;
}
if (countOfRoses >= 10 && season == "Winter")
{
	totalPrice *= 0.90;
}
if (sumOfFlowers > 20)
{
	totalPrice *= 0.8;
}
//Output
totalPrice += 2;
Console.WriteLine($"{totalPrice:f2}");
