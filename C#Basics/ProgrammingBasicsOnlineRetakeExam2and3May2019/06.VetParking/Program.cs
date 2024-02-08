int days = int.Parse(Console.ReadLine());   
int hours = int.Parse(Console.ReadLine());

double totalPrice = 0;
for (int day = 1; day <= days; day++)
{
    double price = 0;
    double priceForDay = 0;
    for (int hour = 1; hour <= hours ; hour++)
    {
        if (day % 2 == 0 && hour % 2 != 0)
        {
            price = 2.50;
        }else if (day % 2 != 0 && hour % 2 == 0)
        {
            price = 1.25;
        }
        else
        {
            price = 1;
        }
        priceForDay += price;
    }
    Console.WriteLine($"Day: {day} - {priceForDay:f2} leva");
    totalPrice += priceForDay;
}
Console.WriteLine($"Total: {totalPrice:f2} leva");