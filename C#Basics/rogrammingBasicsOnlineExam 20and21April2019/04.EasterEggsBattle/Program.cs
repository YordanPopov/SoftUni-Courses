int firstPlayerEggs = int.Parse(Console.ReadLine());    
int seconfPlayerEggs = int.Parse(Console.ReadLine());

bool isEnd = true;
string winner = Console.ReadLine();
while (winner != "End")
{
    if (winner == "one")
    {
        seconfPlayerEggs--;
    }else if (winner == "two")
    {
        firstPlayerEggs--;
    }
    if (firstPlayerEggs <= 0)
    {
        isEnd = false;
        Console.WriteLine($"Player one is out of eggs. Player two has {seconfPlayerEggs} eggs left.");
        break;
    }
    if (seconfPlayerEggs <= 0)
    {
        isEnd = false;
        Console.WriteLine($"Player two is out of eggs. Player one has {firstPlayerEggs} eggs left.");
        break;
    }
    winner = Console.ReadLine();
}
if (isEnd)
{
    Console.WriteLine($"Player one has {firstPlayerEggs} eggs left.");
    Console.WriteLine($"Player two has {seconfPlayerEggs} eggs left.");
}