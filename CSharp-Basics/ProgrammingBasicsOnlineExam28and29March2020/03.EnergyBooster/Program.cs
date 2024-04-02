string fruit = Console.ReadLine();
string setSize = Console.ReadLine();
int countOfSets = int.Parse(Console.ReadLine());

double totalPrice = 0;
double setPrice = 0;

switch (fruit)
{
	case "Watermelon":
        if (setSize == "small")
        {
            setPrice = 2 * 56;
        }
        else if (setSize == "big")
        {
            setPrice = 5 * 28.70;
        }
        break;
	case "Mango":
        if (setSize == "small")
        {
            setPrice = 2 * 36.66;
        }
        else if (setSize == "big")
        {
            setPrice = 5 * 19.60;
        }
        break;
	case "Pineapple":
        if (setSize == "small")
        {
            setPrice = 2 * 42.10;
        }
        else if (setSize == "big")
        {
            setPrice = 5 * 24.80;
        }
        break;
	case "Raspberry":
        if (setSize == "small")
        {
            setPrice = 2 * 20;
        }
        else if (setSize == "big")
        {
            setPrice = 5 * 15.20;
        }
        break;

    default:
		break;
}
totalPrice = countOfSets * setPrice;
if (totalPrice >= 400 && totalPrice <= 1000)
{
    totalPrice *= 0.85;
} else if (totalPrice > 1000)
{
    totalPrice *= 0.5;
}

Console.WriteLine($"{totalPrice:f2} lv.");