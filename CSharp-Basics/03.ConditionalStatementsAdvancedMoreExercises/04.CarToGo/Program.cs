//Input
double budget = double.Parse(Console.ReadLine());   
string season = Console.ReadLine();

//Caluclations
string typeOfCar = "";
string classOfCar = "";
double priceForCar = 0;

if (budget <= 100)
{
    classOfCar = "Economy class";
    if (season == "Summer")
    {
        typeOfCar = "Cabrio";
        priceForCar = budget * 0.35;
    }else if (season == "Winter")
    {
        typeOfCar = "Jeep";
        priceForCar = budget * 0.65;
    }
}
else if (budget > 100 && budget <= 500 )
{
    classOfCar = "Compact class";
    if (season == "Summer")
    {
        typeOfCar = "Cabrio";
        priceForCar = budget * 0.45;
    }else if (season == "Winter")
    {
        typeOfCar = "Jeep";
        priceForCar = budget * 0.80;
    }
}
else if (budget > 500)
{
    classOfCar = "Luxury class";
    typeOfCar = "Jeep";
    priceForCar = budget * 0.9;
}
//Output
Console.WriteLine($"{classOfCar}");
Console.WriteLine($"{typeOfCar} - {priceForCar:f2}");