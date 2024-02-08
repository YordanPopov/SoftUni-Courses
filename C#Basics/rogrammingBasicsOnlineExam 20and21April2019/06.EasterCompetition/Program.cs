int cakes = int.Parse(Console.ReadLine());

int maxPoints = int.MinValue;
string bestBaker = "";
bool isBest = false;
for (int cake = 1; cake <= cakes; cake++)
{
    int bakerPoints = 0;
    string bakerName = Console.ReadLine();
    string Command = (Console.ReadLine());
    while (Command != "Stop")
    {
        int rate = int.Parse(Command);
        bakerPoints += rate;
        if (bakerPoints > maxPoints)
        {
            maxPoints = bakerPoints;
            bestBaker = bakerName;
            isBest = true;
        }
        Command = Console.ReadLine();
    }
    Console.WriteLine($"{bakerName} has {bakerPoints} points.");
    if (isBest)
    {
        Console.WriteLine($"{bakerName} is the new number 1!");
    }
    isBest = false;
}
Console.WriteLine($"{bestBaker} won competition with {maxPoints} points!");