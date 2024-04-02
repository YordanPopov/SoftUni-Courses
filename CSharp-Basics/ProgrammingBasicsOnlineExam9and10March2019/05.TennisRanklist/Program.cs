int numberOfTournaments = int.Parse(Console.ReadLine());
int startingPoints = int.Parse(Console.ReadLine());

int totalPoints = 0;
int tournamentsWins = 0;
for (int tournament = 0; tournament < numberOfTournaments; tournament++)
{
    string tournamentStage = Console.ReadLine();
	switch (tournamentStage)
	{
		case "W": tournamentsWins++; totalPoints += 2000; break;
		case "F": totalPoints += 1200; break;
		case "SF": totalPoints += 720; break;
		default:
			break;
	}
}
Console.WriteLine($"Final points: {startingPoints + totalPoints}");
Console.WriteLine($"Average points: {Math.Floor(totalPoints / (double)numberOfTournaments)}");
Console.WriteLine($"{(double)tournamentsWins / numberOfTournaments * 100.0:f2}%");