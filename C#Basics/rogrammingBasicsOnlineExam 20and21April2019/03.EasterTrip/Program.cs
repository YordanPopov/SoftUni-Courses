string destination = Console.ReadLine();
string dates = Console.ReadLine();
int numberOvernightStays = int.Parse(Console.ReadLine());

double overnightStayPrice = 0.0;
switch (destination)
{
	case "France":
		switch (dates)
		{
			case "21-23": overnightStayPrice = 30; break;
			case "24-27": overnightStayPrice = 35; break;
			case "28-31": overnightStayPrice = 40; break;
			default:
				break;
		}
		break;
	case "Italy": 
		switch (dates)
        {
            case "21-23": overnightStayPrice = 28; break;
            case "24-27": overnightStayPrice = 32; break;
            case "28-31": overnightStayPrice = 39; break;
            default:
                break;
        }
        break;
	case "Germany":
        switch (dates)
        {
            case "21-23": overnightStayPrice = 32; break;
            case "24-27": overnightStayPrice = 37; break;
            case "28-31": overnightStayPrice = 43; break;
            default:
                break;
        }
        break; 
	default:
		break;
}

double totalSum = numberOvernightStays * overnightStayPrice;
Console.WriteLine($"Easter trip to {destination} : {totalSum:f2} leva.");