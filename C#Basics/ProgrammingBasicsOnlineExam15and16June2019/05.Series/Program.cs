double budget = double.Parse(Console.ReadLine());
int numberOfSerials = int.Parse(Console.ReadLine());

double totalPrice = 0;
for (int serial = 0; serial < numberOfSerials; serial++)
{
    string name = Console.ReadLine();  
    double price = double.Parse(Console.ReadLine());
    switch (name)
    {
        case "Thrones": price *= 0.5; break;
        case "Lucifer": price *= 0.6; break;
        case "Protector": price *= 0.7; break;
        case "TotalDrama": price *= 0.8; break;
        case "Area": price *= 0.9; break;
        default:
            break;
    }
    totalPrice += price;
}

if (budget >= totalPrice)
{
    Console.WriteLine($"You bought all the series and left with {budget - totalPrice:f2} lv.");
}
else
{
    Console.WriteLine($"You need {totalPrice - budget:f2} lv. more to buy the series!");
}