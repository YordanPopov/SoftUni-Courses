double trunkCapacity = double.Parse(Console.ReadLine());

int suitcaseCounter = 0;
bool isFull = false;
string input = Console.ReadLine();

while (input != "End")
{
    double suitcaseVolume = double.Parse(input);
    if ((suitcaseCounter + 1) % 3 == 0)
    {
        suitcaseVolume *= 1.1;
    }
    if (trunkCapacity < suitcaseVolume)
    {
        isFull = true;
        break;

    }
    suitcaseCounter++; 
    trunkCapacity -= suitcaseVolume;
    
    input = Console.ReadLine();
}

if (!isFull)
{
    Console.WriteLine("Congratulations! All suitcases are loaded!");
    Console.WriteLine($"Statistic: {suitcaseCounter} suitcases loaded.");
}
else
{
    Console.WriteLine("No more space!");
    Console.WriteLine($"Statistic: {suitcaseCounter} suitcases loaded.");
}