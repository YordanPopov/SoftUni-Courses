//Input
string month = Console.ReadLine();
int countOvernightStay = int.Parse(Console.ReadLine());

//Calculations
double costOvernightStayStudio = 0;
double costOvernightStayApartment = 0;


switch (month)
{
	case "May":
	case "October":
		costOvernightStayStudio = 50;
		costOvernightStayApartment = 65;
		break;
	case "June":
	case "September":
		costOvernightStayStudio = 75.2;
		costOvernightStayApartment = 68.7;
		break;
	case "July":
	case "August":
		costOvernightStayStudio = 76;
		costOvernightStayApartment = 77;
		break;
	default:
		break;
}

double totalPriceStudio = costOvernightStayStudio * countOvernightStay;
double totalPriceApartment = costOvernightStayApartment * countOvernightStay;

if (month == "May" || month == "October")
{
    if (countOvernightStay > 7 && countOvernightStay <= 14)
    {
		totalPriceStudio *= 0.95;
    }else if (countOvernightStay > 14)
    {
		totalPriceStudio *= 0.7;
    }
}else if (month == "June" || month == "September")
{
    if (countOvernightStay > 14)
    {
		totalPriceStudio *= 0.8;
    }
}
if (countOvernightStay > 14)
{
	totalPriceApartment *= 0.9;
}
//Output
Console.WriteLine($"Apartment: {totalPriceApartment:f2} lv.");
Console.WriteLine($"Studio: {totalPriceStudio:f2} lv.");