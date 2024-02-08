int countOfTournaments = int.Parse(Console.ReadLine());
int startingPoints = int.Parse(Console.ReadLine());

double totalPoints = 0;
int winTournaments = 0;
for (int i = 1; i <= countOfTournaments ; i++)
{
    string stageOfTournament = Console.ReadLine();
	switch (stageOfTournament)
	{
		case "W": totalPoints += 2000; winTournaments++; break;
		case "F": totalPoints += 1200; break;
		case "SF": totalPoints += 720; break;
		default:
			break;
	}
}

double avrPoints = (totalPoints / (double)countOfTournaments);
double percentWiningTournaments = (winTournaments / (double)countOfTournaments) * 100.0;

Console.WriteLine($"Final points: {(totalPoints + startingPoints)}");
Console.WriteLine($"Average points: {Math.Floor(avrPoints)}");
Console.WriteLine($"{percentWiningTournaments:f2}%");