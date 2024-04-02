string playerName = Console.ReadLine();

int maxPoint = int.MinValue;
string bestPlayerName = "";
while (playerName != "Stop")
{
    int points = 0;
    for (int i = 0; i < playerName.Length; i++)
    {
        int number = int.Parse(Console.ReadLine());
        if (number == (int)playerName[i])
        {
            points += 10;
        }
        else
        {
            points += 2;
        }
    }
    if (points >= maxPoint)
    {
        maxPoint = points;
        bestPlayerName = playerName;
    }
    playerName = Console.ReadLine();
}
Console.WriteLine($"The winner is {bestPlayerName} with {maxPoint} points!");