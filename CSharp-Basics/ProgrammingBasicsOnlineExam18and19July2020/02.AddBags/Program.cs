double priceForBaggageUp20kg = double.Parse(Console.ReadLine());
double baggageKg = double.Parse(Console.ReadLine());    
int dayTotrip = int.Parse(Console.ReadLine());
int numberOfBaggage = int.Parse(Console.ReadLine());

double totalPrice = 0;
double priceForBaggage = 0;

if (baggageKg < 10)
{
    priceForBaggage = priceForBaggageUp20kg - (priceForBaggageUp20kg * 0.8);  
}else if (baggageKg >= 10 && baggageKg <= 20)
{
    priceForBaggage = priceForBaggageUp20kg - (priceForBaggageUp20kg * 0.5);
}else if (baggageKg > 20)
{
    priceForBaggage = priceForBaggageUp20kg;
}

if (dayTotrip > 30)
{
    priceForBaggage *= 1.1;
}
else if (dayTotrip >= 7 && dayTotrip <= 30)
{
    priceForBaggage *= 1.15;
}
else if (dayTotrip < 7)
{
    priceForBaggage *= 1.4;
}
totalPrice = priceForBaggage * numberOfBaggage;

Console.WriteLine($" The total price of bags is: {totalPrice:f2} lv. ");