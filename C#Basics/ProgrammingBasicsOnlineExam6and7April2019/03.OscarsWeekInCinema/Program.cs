string movieName = Console.ReadLine();
string hall = Console.ReadLine();
int tickets = int.Parse(Console.ReadLine());

double ticketPrice = 0.0;

switch (movieName)
{
	case "A Star Is Born": 
		switch (hall)
		{
			case "normal": ticketPrice = 7.50; break;
			case "luxury": ticketPrice = 10.50; break;
			case "ultra luxury": ticketPrice = 13.50;  break;
            default:
				break;
		}
        break;
    case "Bohemian Rhapsody":
        switch (hall)
        {
            case "normal": ticketPrice = 7.35; break;
            case "luxury": ticketPrice = 9.45; break;
            case "ultra luxury": ticketPrice = 12.75; break;
            default:
                break;
        }
        break;
	case "Green Book":
        switch (hall)
        {
            case "normal": ticketPrice = 8.15; break;
            case "luxury": ticketPrice = 10.25; break;
            case "ultra luxury": ticketPrice = 13.25; break;
            default:
                break;
        }
        break;
	case "The Favourite":
        switch (hall)
        {
            case "normal": ticketPrice = 8.75; break;
            case "luxury": ticketPrice = 11.55; break;
            case "ultra luxury": ticketPrice = 13.95; break;
            default:
                break;
        }
        break;
    default:
		break;
}

double totalPrice = ticketPrice * tickets;
Console.WriteLine($"{movieName} -> {totalPrice:f2} lv.");