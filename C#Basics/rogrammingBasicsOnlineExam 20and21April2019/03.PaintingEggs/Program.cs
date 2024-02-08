string eggSize = Console.ReadLine();
string eggColour = Console.ReadLine();
int numberOfBatch = int.Parse(Console.ReadLine());

double batchPrice = 0.0;

switch (eggSize)
{
	case "Large":
		switch (eggColour)
		{
			case "Red": batchPrice = 16; break;
			case "Green": batchPrice = 12; break;
			case "Yellow": batchPrice = 9; break;
			default:
				break;
		}
		break;
	case "Medium":
        switch (eggColour)
        {
            case "Red": batchPrice = 13; break;
            case "Green": batchPrice = 9; break;
            case "Yellow": batchPrice = 7; break;
            default:
                break;
        }
        break;
	case "Small":
        switch (eggColour)
        {
            case "Red": batchPrice = 9; break;
            case "Green": batchPrice = 8; break;
            case "Yellow": batchPrice = 5; break;
            default:
                break;
        }
        break;
	default:
		break;
}

double totalSum = numberOfBatch * batchPrice;
totalSum *= 0.65;
Console.WriteLine($"{totalSum:f2} leva.");