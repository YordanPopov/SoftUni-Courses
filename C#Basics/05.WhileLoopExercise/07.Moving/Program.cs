int wFreeSpace = int.Parse(Console.ReadLine());
int lFreeSpace = int.Parse(Console.ReadLine());
int hFreeSpace = int.Parse(Console.ReadLine());

int freeSpace = wFreeSpace * lFreeSpace * hFreeSpace;
int occupiedSpace = 0;

while (occupiedSpace < freeSpace)
{
    string input = Console.ReadLine();
    if (input == "Done")
    {
        break;
    }
    int countOfBox = int.Parse(input);
    occupiedSpace += countOfBox;
}

if (freeSpace >= occupiedSpace)
{
    Console.WriteLine($"{freeSpace - occupiedSpace} Cubic meters left.");
}
else
{
    Console.WriteLine($"No more free space! You need {Math.Abs(occupiedSpace - freeSpace)} Cubic meters more.");
}