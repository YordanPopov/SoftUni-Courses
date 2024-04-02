double budget = double.Parse(Console.ReadLine());
string destination = Console.ReadLine();
string season = Console.ReadLine();
int days = int.Parse(Console.ReadLine());

double photoPrice = 0.0;

switch (season)
{
    case "Winter":
        switch (destination)
		{
			case "Dubai": photoPrice = 45_000; break;
			case "Sofia": photoPrice = 17_000; break;
			case "London": photoPrice = 24_000; break;
            default:
				break;
		}
        break;

    case "Summer":
        switch (destination)
        {
            case "Dubai": photoPrice = 40_000; break;
            case "Sofia": photoPrice = 12_500; break;
            case "London": photoPrice = 20_250; break;
            default:
                break;
        }
        break;
    default:
		break;
}
double totalPrice = days * photoPrice;

if (destination == "Dubai")
{
    totalPrice *= 0.7;
}else if (destination == "Sofia")
{
    totalPrice *= 1.25;
}

if (budget >= totalPrice)
{
    Console.WriteLine($"The budget for the movie is enough! We have {budget - totalPrice:f2} leva left!");
}
else
{
    Console.WriteLine($"The director needs {totalPrice - budget:f2} leva more!");
}