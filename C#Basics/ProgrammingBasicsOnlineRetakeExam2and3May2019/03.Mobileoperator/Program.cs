string contractTerm = Console.ReadLine();
string contractType = Console.ReadLine();
string mobileNetwork = Console.ReadLine();
int months = int.Parse(Console.ReadLine());

double fee = 0.0;
switch (contractType)
{
	case "Small":
        if (contractTerm == "one")
        {
            fee = 9.98;
        }else if (contractTerm == "two")
        {
            fee = 8.58;
        }
        break;
	case "Middle":
        if (contractTerm == "one")
        {
            fee = 18.99;
        }
        else if (contractTerm == "two")
        {
            fee = 17.09;
        }
        break;
	case "Large":
        if (contractTerm == "one")
        {
            fee = 25.98;
        }
        else if (contractTerm == "two")
        {
            fee = 23.59;
        }
        break;
	case "ExtraLarge":
        if (contractTerm == "one")
        {
            fee = 35.99;
        }
        else if (contractTerm == "two")
        {
            fee = 31.79;
        }
        break;
	default:
		break;
}
if (mobileNetwork == "yes")
{
    if (fee <= 10)
    {
        fee += 5.50;
    }else if (fee > 10 && fee <= 30)
    {
        fee += 4.35;
    }else if (fee > 30)
    {
        fee += 3.85;
    }
}
double totalPrice = fee * months;
if (contractTerm == "two")
{
    totalPrice *= 0.9625;
}
Console.WriteLine($"{totalPrice:f2} lv.");