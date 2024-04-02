double vaucher = double.Parse(Console.ReadLine());

int tickets = 0;
bool isTicket = false;
bool isOtherPurchase = false;
int otherPurchase = 0;

while (true)
{
    double ticketOrOtherPrice = 0.0;
    string purchase = Console.ReadLine();
    if (purchase == "End")
    {
        break;
    }
    if (purchase.Length > 8)
    {
        isTicket = true;
        ticketOrOtherPrice = (purchase[0] + purchase[1]);
    }else if (purchase.Length <= 8)
    {
        isOtherPurchase = true;
        ticketOrOtherPrice = purchase[0];
    }
    if (ticketOrOtherPrice <= vaucher)
    {
        vaucher -= ticketOrOtherPrice;
    }
    else
    {
        break;
    }
    if (isTicket)
    {
        tickets++;
        isTicket = false;
    }
    if (isOtherPurchase)
    {
        otherPurchase++;
        isOtherPurchase = false;
    }
}
Console.WriteLine($"{tickets}");
Console.WriteLine($"{otherPurchase}");