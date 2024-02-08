//Input
int countOfJuniors = int.Parse(Console.ReadLine());
int countOfSeniors = int.Parse(Console.ReadLine()); 
string typeOfRace = Console.ReadLine();

//Caluclations
double feeForJuniors = 0;
double feeForSeniors = 0;

switch (typeOfRace)
{
	case "trail":
		feeForJuniors = 5.50;
		feeForSeniors = 7;
		break;
	case "cross-country":
		feeForJuniors = 8;
		feeForSeniors = 9.50;
		break;
	case "downhill":
		feeForJuniors = 12.25;
		feeForSeniors = 13.75;
		break;
	case "road":
		feeForJuniors = 20;
		feeForSeniors = 21.50;
		break;
    default:
		break;
}
double totalPrice = ((countOfJuniors * feeForJuniors) + (countOfSeniors * feeForSeniors)) * 0.95;
if (typeOfRace == "cross-country" )
{
    if ((countOfJuniors + countOfSeniors) >= 50)
    {
		totalPrice *= 0.75;
    }
}
//Output
Console.WriteLine($"{totalPrice:f2}");