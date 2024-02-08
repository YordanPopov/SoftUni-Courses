int capacityOfStadium = int.Parse(Console.ReadLine());
int countOfFans = int.Parse(Console.ReadLine());

double fanSectorA = 0;
double fanSectorB = 0;
double fanSectorV = 0;
double fanSectorG = 0;

for (int fan = 0; fan < countOfFans; fan++)
{
    string sector = Console.ReadLine();
	switch (sector)
	{
		case "A": fanSectorA++; break;
		case "B": fanSectorB++; break;
		case "V": fanSectorV++; break;
		case "G": fanSectorG++; break;
		default:
			break;
	}
}

Console.WriteLine($"{fanSectorA / countOfFans * 100.0:f2}%");
Console.WriteLine($"{fanSectorB / countOfFans * 100.0:f2}%");
Console.WriteLine($"{fanSectorV / countOfFans * 100.0:f2}%");
Console.WriteLine($"{fanSectorG / countOfFans * 100.0:f2}%");
Console.WriteLine($"{(double)countOfFans / capacityOfStadium * 100.0:f2}%");