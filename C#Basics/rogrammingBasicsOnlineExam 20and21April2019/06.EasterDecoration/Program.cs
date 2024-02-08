
int clients = int.Parse(Console.ReadLine());

double totalSum = 0;
bool isFinish = false;
for (int client = 1; client <= clients ; client++)
{
    double purchasePrice = 0;
    double priceForClient = 0;
    int purchaseCounter = 0;
    while (true)
    {
       string purchase = Console.ReadLine();
        if (purchase == "Finish")
        {
            isFinish = true;
            break;
        }
        switch (purchase)
        {
            case "basket": purchasePrice = 1.50; break;
            case "wreath":purchasePrice = 3.80;  break;
            case "chocolate bunny": purchasePrice = 7; break;
                default: break;
        }
        purchaseCounter++;
        priceForClient += purchasePrice; 
    }
    if (purchaseCounter % 2 == 0)
    {
        priceForClient *= 0.8;
    }
    totalSum += priceForClient;
    if (isFinish)
    {
        Console.WriteLine($"You purchased {purchaseCounter} items for {priceForClient:f2} leva.");
    }
}
Console.WriteLine($"Average bill per client is: {totalSum / clients:f2} leva.");