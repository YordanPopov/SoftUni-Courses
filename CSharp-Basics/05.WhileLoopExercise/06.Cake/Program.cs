int widthOfCake = int.Parse(Console.ReadLine());
int lengthOfCake = int.Parse(Console.ReadLine());

int countOfCake = widthOfCake * lengthOfCake;

while (countOfCake > 0)
{
    string input = Console.ReadLine();
    if (input == "STOP" && countOfCake > 0)
    {
        break;
    }
    int pieceFfCake = int.Parse(input);
    countOfCake -= pieceFfCake;
}

if (countOfCake > 0)
{
    Console.WriteLine($"{countOfCake} pieces are left.");
}
else
{
    Console.WriteLine($"No more cake left! You need {Math.Abs(countOfCake)} pieces more.");
}