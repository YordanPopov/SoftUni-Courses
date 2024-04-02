int numberOfBalls = int.Parse(Console.ReadLine());

double totalPoints = 0;
int redBall = 0;
int orangeBall = 0;
int yellowBall = 0;
int whiteBall = 0;
int blackBall = 0;
int otherBall = 0;

for (int i = 0; i < numberOfBalls; i++)
{
    string typeOfBall = Console.ReadLine();

	switch (typeOfBall)
	{
		case "red": totalPoints += 5; redBall++; break;
		case "orange": totalPoints += 10; orangeBall++; break;
		case "yellow": totalPoints += 15; yellowBall++; break;
		case "white": totalPoints += 20; whiteBall++; break;
		case "black": totalPoints = Math.Floor(totalPoints / 2); blackBall++; break;
		default:
			otherBall++;
			break;
	}
}

Console.WriteLine($"Total points: {totalPoints}");
Console.WriteLine($"Red balls: {redBall}");
Console.WriteLine($"Orange balls: {orangeBall}");
Console.WriteLine($"Yellow balls: {yellowBall}");
Console.WriteLine($"White balls: {whiteBall}");
Console.WriteLine($"Other colors picked: {otherBall}");
Console.WriteLine($"Divides from black balls: {blackBall}");