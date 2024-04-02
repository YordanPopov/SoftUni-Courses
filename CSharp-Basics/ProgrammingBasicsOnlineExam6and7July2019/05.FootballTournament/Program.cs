string nameOfTeam = Console.ReadLine();
int numberOfMatchs = int.Parse(Console.ReadLine());

int totalPoint = 0;
int wins = 0;
int loses = 0;
int drawns = 0;


for (int match = 0; match < numberOfMatchs; match++)
{
    string result = Console.ReadLine();

    if (result == "W")
    {
        totalPoint += 3;
        wins++;
    }else if (result == "D")
    {
        totalPoint += 1;
        drawns++;
    }else if (result == "L")
    {
        loses++;
    }
}
if (numberOfMatchs <= 0)
{
    Console.WriteLine($"{nameOfTeam} hasn't played any games during this season.");
}
else
{
    Console.WriteLine($"{nameOfTeam} has won {totalPoint} points during this season.");
    Console.WriteLine("Total stats:");
    Console.WriteLine($"## W: {wins}");
    Console.WriteLine($"## D: {drawns}");
    Console.WriteLine($"## L: {loses}");
    Console.WriteLine($"Win rate: {(double)wins / numberOfMatchs * 100:f2}%");
}