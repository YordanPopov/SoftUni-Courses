string nameOfPlayer = Console.ReadLine();

string bestPlayer = "";
int maxGoals = 0;
bool ishatTrick = false;
bool isTrue = false;
while (nameOfPlayer != "END")
{
    int goals = int.Parse(Console.ReadLine());
    if (goals >= 10)
    {
        ishatTrick = true;
        isTrue = true;
    }
    if (goals >= 3)
    {
        ishatTrick = true;
    }
    if (goals > maxGoals)
    {
        maxGoals = goals;
        bestPlayer = nameOfPlayer;
    }
    if (isTrue)
    {
        break;
    }
    nameOfPlayer = Console.ReadLine();
}
if (!isTrue)
{
    Console.WriteLine($"{bestPlayer} is the best player!");
    if (ishatTrick)
    {
        Console.WriteLine($"He has scored {maxGoals} goals and made a hat-trick !!!");
    }
    else
    {
        Console.WriteLine($"He has scored {maxGoals} goals.");
    }
}
else
{
    Console.WriteLine($"{bestPlayer} is the best player!");
    Console.WriteLine($"He has scored {maxGoals} goals and made a hat-trick !!!");
}