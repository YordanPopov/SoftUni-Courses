//Input
string typeOfProjection = Console.ReadLine();
int numberOfRows = int.Parse(Console.ReadLine());
int numberOfColumns = int.Parse(Console.ReadLine());

//Calculations and Output
double income = 0;
switch (typeOfProjection)
{
	case "Premiere":
		income = numberOfRows * numberOfColumns * 12.00;
        Console.WriteLine($"{income:f2} leva");
        break;
	case "Normal":
		income = numberOfRows * numberOfColumns * 7.50;
        Console.WriteLine($"{income:f2} leva");
        break;
	case "Discount":
		income = numberOfRows * numberOfColumns * 5.00;
        Console.WriteLine($"{income:f2} leva");
        break;
	default:
		break;
}