string projection = Console.ReadLine();
string packet = Console.ReadLine();
int tickets = int.Parse(Console.ReadLine());

double ticketPrice = 0.0;

switch (projection)
{
	case "John Wick":
		switch (packet)
		{
			case "Drink": ticketPrice = 12; break;
			case "Popcorn": ticketPrice = 15; break;
			case "Menu": ticketPrice = 19; break;
            default:
				break;
		}
		break;
	case "Star Wars":
        switch (packet)
        {
            case "Drink": ticketPrice = 18; break;
            case "Popcorn": ticketPrice = 25; break;
            case "Menu": ticketPrice = 30; break;
            default:
                break;
        }
        break;
	case "Jumanji":
        switch (packet)
        {
            case "Drink": ticketPrice = 9; break;
            case "Popcorn": ticketPrice = 11; break;
            case "Menu": ticketPrice = 14; break;
            default:
                break;
        }
        break;
    default:
		break;
}

double totalPrice = ticketPrice * tickets;

if (projection == "Star Wars" && tickets >= 4)
{
    totalPrice *= 0.7;

}else if (projection == "Jumanji" && tickets == 2)
{
    totalPrice *= 0.85;
}

Console.WriteLine($"Your bill is {totalPrice:f2} leva.");