
string filmName = Console.ReadLine();
int filmCounter = 0;
string bestFilm = "";
int maxPoints = int.MinValue;
int sum = 0;
while (true)
{
    if (filmName == "STOP")
    {
        break;
    }
    filmCounter++;
    if (filmCounter > 6)
    {
        Console.WriteLine("The limit is reached.");
        break;
    }
    for (int i = 0; i < filmName.Length; i++)
    {
        char currentSymbol = filmName[i];
        int currentDigid = (int)currentSymbol;
        if (currentSymbol >= 'A' && currentSymbol <= 'Z')
        {
            sum += currentDigid - filmName.Length;
        }else if (currentSymbol >= 'a' && currentSymbol <= 'z')
        {
            sum += currentDigid - (2 * filmName.Length);
        }
        else
        {
            sum += currentDigid;
        }
    }
    if (sum > maxPoints)
    {
        maxPoints = sum;
        bestFilm = filmName;
    }
    sum = 0;
    filmName = Console.ReadLine();
}

Console.WriteLine($"The best movie for you is {bestFilm} with {maxPoints} ASCII sum.");