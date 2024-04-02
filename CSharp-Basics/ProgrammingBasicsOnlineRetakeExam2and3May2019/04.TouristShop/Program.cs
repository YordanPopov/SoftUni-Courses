double budget = double.Parse(Console.ReadLine());

int productCounter = 0;
double totalPrice = 0;


while (true)
{
    string productName = Console.ReadLine();
    if (productName == "Stop")
    {
        Console.WriteLine($"You bought {productCounter} products for {totalPrice:f2} leva.");
        break;
    }

    double productPrice = double.Parse(Console.ReadLine());
    productCounter++;

    if (productCounter % 3 == 0)
    {
        productPrice *= 0.5;
    }
    if (productPrice > budget)
    {
        Console.WriteLine("You don't have enough money!");
        Console.WriteLine($"You need {productPrice - budget:f2} leva!");
        break;
    }
    budget -= productPrice;   
    totalPrice += productPrice;
}
