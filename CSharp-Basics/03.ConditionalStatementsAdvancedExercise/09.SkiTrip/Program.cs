//Input
int dayStay = int.Parse(Console.ReadLine()) - 1;
string typeOfRoom = Console.ReadLine();
string rating = Console.ReadLine();

//Calculations
double costOvernightStay = 0;

switch (typeOfRoom)
{
	case "room for one person": costOvernightStay = 18.00; break;
	case "apartment": costOvernightStay = 25.00; break;
	case "president apartment": costOvernightStay = 35.00; break;
    default:
		break;
}

double totalPriceForStay = dayStay * costOvernightStay;

if (typeOfRoom == "apartment")
{
    if (dayStay < 10)
    {
        totalPriceForStay *= 0.7;
    }else if(dayStay >= 10 && dayStay <= 15)
    {
        totalPriceForStay *= 0.65;
    }else if (dayStay > 15)
    {
        totalPriceForStay *= 0.5;
    }
}
else if (typeOfRoom == "president apartment")
{
    if (dayStay < 10)
    {
        totalPriceForStay *= 0.9;
    }else if (dayStay >= 10 && dayStay <= 15)
    {
        totalPriceForStay *= 0.85;
    }else if (dayStay > 15)
    {
        totalPriceForStay *= 0.8;
    }
}
if (rating == "positive")
{
    totalPriceForStay *= 1.25;
}else if (rating == "negative")
{
    totalPriceForStay *= 0.9;
}

//Output
Console.WriteLine($"{totalPriceForStay:f2}");