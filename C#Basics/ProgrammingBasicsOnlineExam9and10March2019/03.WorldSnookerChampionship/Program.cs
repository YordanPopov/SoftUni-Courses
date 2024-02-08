using System.Runtime.CompilerServices;

string championshipStage = Console.ReadLine();
string ticketType = Console.ReadLine();
int numberOfTickets = int.Parse(Console.ReadLine());
string picturesWithTrophy = Console.ReadLine();

double ticketPrise = 0.0;
double picturesWithTrophyPrice = 0;
if (picturesWithTrophy == "Y")
{
    picturesWithTrophyPrice = 40.0;
}

switch (championshipStage)
{
	case "Quarter final":
		switch (ticketType)
		{
			case "Standard": ticketPrise = 55.50;  break;
			case "Premium": ticketPrise = 105.20; break;
			case "VIP": ticketPrise = 118.90; break;
            default: break;
		}
		break;
	case "Semi final":
        switch (ticketType)
        {
            case "Standard": ticketPrise = 75.88; break;
            case "Premium": ticketPrise = 125.22; break;
            case "VIP": ticketPrise = 300.40; break;
            default: break;
        }
        break;
	case "Final":
        switch (ticketType)
        {
            case "Standard": ticketPrise = 110.10; break;
            case "Premium": ticketPrise = 160.66; break;
            case "VIP": ticketPrise = 400; break;
            default:
                break;
        }
        break;
    default: break;
}
double totalPrice = numberOfTickets * ticketPrise;
if (totalPrice > 4000)
{
    totalPrice *= 0.75;

}else if ( totalPrice > 2500 && totalPrice <= 4000)
{
    totalPrice *= 0.9;
    totalPrice += picturesWithTrophyPrice * numberOfTickets;
}
else
{
    totalPrice += picturesWithTrophyPrice * numberOfTickets;
}

Console.WriteLine($"{totalPrice:f2}");
