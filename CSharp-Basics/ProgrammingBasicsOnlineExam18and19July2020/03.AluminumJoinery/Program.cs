int numberOfJoinery = int.Parse(Console.ReadLine());
string typeOfJoinery = Console.ReadLine();  
string typeOfDelivery = Console.ReadLine();

double totalPrice = 0;
double priceForJoynery = 0;

if (typeOfJoinery == "90X130")
{
    priceForJoynery = 110;

    if (numberOfJoinery > 30 && numberOfJoinery <= 60)
    {
        priceForJoynery *= 0.95;
    }else if (numberOfJoinery > 60)
    {
        priceForJoynery *= 0.92;
    }
}else if (typeOfJoinery == "100X150")
{
    priceForJoynery = 140;

    if (numberOfJoinery > 40 && numberOfJoinery <= 80)
    {
        priceForJoynery *= 0.94;
    }else if (numberOfJoinery > 80)
    {
        priceForJoynery *= 0.9;
    }
}else if (typeOfJoinery == "130X180")
{
    priceForJoynery = 190;

    if (numberOfJoinery > 20 && numberOfJoinery <= 50)
    {
        priceForJoynery *= 0.93;
    }else if (numberOfJoinery > 50)
    {
        priceForJoynery *= 0.88;
    }
}else if (typeOfJoinery == "200X300")
{
    priceForJoynery = 250;

    if (numberOfJoinery > 25 && numberOfJoinery <= 50)
    {
        priceForJoynery *= 0.91;
    }else if (numberOfJoinery > 50)
    {
        priceForJoynery *= 0.86;
    }
}

totalPrice = priceForJoynery * numberOfJoinery;

if (typeOfDelivery == "With delivery")
{
    totalPrice += 60;
}

if (numberOfJoinery > 99)
{
    totalPrice *= 0.96;
}

if (numberOfJoinery < 10)
{
    Console.WriteLine("Invalid order");
}
else
{
    Console.WriteLine($"{totalPrice:f2} BGN");
}
