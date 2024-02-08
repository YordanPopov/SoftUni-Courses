int numberOfGames = int.Parse(Console.ReadLine());

int hearthstone = 0;
int fornite = 0;
int overwatch = 0;
int others = 0;

for (int game = 0; game < numberOfGames; game++)
{
    string nameOfGame = Console.ReadLine();
    if (nameOfGame == "Hearthstone")
    {
        hearthstone++;
    }else if (nameOfGame == "Fornite")
    {
        fornite++;
    }else if (nameOfGame == "Overwatch")
    {
        overwatch++;
    }else
    {
        others++;
    }
}

Console.WriteLine($"Hearthstone - {(double)hearthstone / numberOfGames * 100:f2}%");
Console.WriteLine($"Fornite - {(double)fornite / numberOfGames * 100:f2}%");
Console.WriteLine($"Overwatch - {(double)overwatch / numberOfGames * 100:f2}%");
Console.WriteLine($"Others - {(double)others / numberOfGames * 100:f2}%");