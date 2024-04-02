int amountforCharity = int.Parse(Console.ReadLine());

double totalSum = 0;
double sumCC = 0;
double sumCS = 0;
int kindOfTransaction = 1;
int avrCC = 0;
int avrCs = 0;

while (totalSum < amountforCharity)
{
    string input = Console.ReadLine();
    if (input == "End")
    {
        break;
    }
    int money = int.Parse(input);
    if (kindOfTransaction % 2 == 0)
    {
        if (money < 10)
        {
            Console.WriteLine("Error in transaction!");
        }
        else
        {
            Console.WriteLine("Product sold!");
            totalSum += money;
            sumCC += money;
            avrCC++;
        }
    }
    else
    {
        if (money > 100)
        {
            Console.WriteLine("Error in transaction!");
        }
        else
        {
            Console.WriteLine("Product sold!");
            totalSum += money;
            sumCS += money;
            avrCs++;
        }
    }
    kindOfTransaction++;
}

if (totalSum >= amountforCharity)
{
    Console.WriteLine($"Average CS: {sumCS / avrCs:f2}");
    Console.WriteLine($"Average CC: {sumCC / avrCC:f2}");
}
else
{
    Console.WriteLine("Failed to collect required money for charity.");
}