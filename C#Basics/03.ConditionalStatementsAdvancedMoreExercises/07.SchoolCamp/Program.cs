//Input
string season = Console.ReadLine();
string typeOfGroup = Console.ReadLine();
int countOfStudents = int.Parse(Console.ReadLine());   
int countOfStay = int.Parse(Console.ReadLine());

//Calculations
string typeOfSport = "";
double priceForBoysAndGirls = 0;
double priceForMixGroup = 0;
double totalPrice = 0;
//double totalPriceForMixGroup = 0;

switch (season)
{
	case "Winter":
		priceForBoysAndGirls = 9.60;
		priceForMixGroup = 10.0;
		break;
	case "Spring":
		priceForBoysAndGirls = 7.20;
		priceForMixGroup = 9.50;
		break;
	case "Summer":
		priceForBoysAndGirls = 15.0;
		priceForMixGroup = 20.0;
		break;
	default:
		break;
}

if (season == "Winter")
{
    if (typeOfGroup == "girls")
    {
		typeOfSport = "Gymnastics";
    }else if (typeOfGroup == "boys")
    {
		typeOfSport = "Judo";
    }else if (typeOfGroup == "mixed")
    {
		typeOfSport = "Ski";
    }
}
else if (season == "Spring")
{
    if (typeOfGroup == "girls")
    {
        typeOfSport = "Athletics";
    }
    else if (typeOfGroup == "boys")
    {
        typeOfSport = "Tennis";
    }
    else if (typeOfGroup == "mixed")
    {
        typeOfSport = "Cycling";
    }
}
else if (season == "Summer")
{
    if (typeOfGroup == "girls")
    {
        typeOfSport = "Volleyball";
    }
    else if (typeOfGroup == "boys")
    {
        typeOfSport = "Football";
    }
    else if (typeOfGroup == "mixed")
    {
        typeOfSport = "Swimming";
    }
}
if (typeOfGroup == "boys" || typeOfGroup == "girls")
{
    totalPrice = countOfStay * countOfStudents * priceForBoysAndGirls;
}else if (typeOfGroup == "mixed")
{
    totalPrice = countOfStay * countOfStudents * priceForMixGroup;
}
if (countOfStudents >= 10 && countOfStudents < 20)
{
    totalPrice *= 0.95;
}else if (countOfStudents >= 20 && countOfStudents < 50)
{
    totalPrice *= 0.85;
}else if (countOfStudents >= 50)
{
    totalPrice *= 0.5;
}
//Output
Console.WriteLine($"{typeOfSport} {totalPrice:f2} lv.");