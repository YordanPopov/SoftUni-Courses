double availableSum = double.Parse(Console.ReadLine()); 
string gender = Console.ReadLine();
int age = int.Parse(Console.ReadLine());
string sport = Console.ReadLine();

double priceForFitnes = 0;

switch (sport)
{
	case "Gym": 
        if (gender == "m")
        {
            priceForFitnes = 42;
        }else if (gender == "f")
        {
            priceForFitnes = 35;
        }
        break;
    case "Boxing": 
        if (gender == "m")
        {
            priceForFitnes = 41;
        }
        else if (gender == "f")
        {
            priceForFitnes = 37;
        }
        break;
    case "Yoga": 
        if (gender == "m")
        {
            priceForFitnes = 45;
        }
        else if (gender == "f")
        {
            priceForFitnes = 42;
        }
        break;
    case "Zumba": 
        if (gender == "m")
        {
            priceForFitnes = 34;
        }
        else if (gender == "f")
        {
            priceForFitnes = 31;
        }
        break;
    case "Dances": 
        if (gender == "m")
        {
            priceForFitnes = 51;
        }
        else if (gender == "f")
        {
            priceForFitnes = 53;
        }
        break;
    case "Pilates":
        if (gender == "m")
        {
            priceForFitnes = 39;
        }
        else if (gender == "f")
        {
            priceForFitnes = 37;
        }
        break;
    default:
		break;
}

if (age <= 19)
{
    priceForFitnes *= 0.8;
}

if (priceForFitnes <= availableSum)
{
    Console.WriteLine($"You purchased a 1 month pass for {sport}.");
}
else
{
    Console.WriteLine($"You don't have enough money! You need ${priceForFitnes - availableSum:f2} more.");
}