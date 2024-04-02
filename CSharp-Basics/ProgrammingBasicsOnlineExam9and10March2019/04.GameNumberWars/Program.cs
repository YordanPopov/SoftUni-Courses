string firstPlayerName = Console.ReadLine();
string secondPlayerName = Console.ReadLine();

int firstPlayerPoints = 0;
int secondPlayerPoints = 0;
while (true)
{
    string comandOrCardFirstPlayer = Console.ReadLine();
    if (comandOrCardFirstPlayer == "End of game")
    {
        Console.WriteLine($"{firstPlayerName} has {firstPlayerPoints} points");
        Console.WriteLine($"{secondPlayerName} has {secondPlayerPoints} points");
        break;
    }
    int firstPlayerCard = int.Parse(comandOrCardFirstPlayer);
    int secondPlayerCard = int.Parse(Console.ReadLine());
    if (firstPlayerCard > secondPlayerCard)
    {
        firstPlayerPoints += firstPlayerCard - secondPlayerCard;
    }else if (firstPlayerCard < secondPlayerCard)
    {
        secondPlayerPoints += secondPlayerCard - firstPlayerCard;
    }
    else
    {
        Console.WriteLine("Number wars!");
        comandOrCardFirstPlayer = Console.ReadLine();
        firstPlayerCard = int.Parse(comandOrCardFirstPlayer);
        secondPlayerCard = int.Parse(Console.ReadLine());
        if (firstPlayerCard > secondPlayerCard)
        {
            Console.WriteLine($"{firstPlayerName} is winner with {firstPlayerPoints} points");
            break;
        }else if (secondPlayerCard > firstPlayerCard)
        {
            Console.WriteLine($"{secondPlayerName} is winner with {secondPlayerPoints} points");
            break;
        }
    }
}
