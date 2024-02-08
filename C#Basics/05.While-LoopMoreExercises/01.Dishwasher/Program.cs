int bottles = int.Parse(Console.ReadLine());

int amountOfDetergent = bottles * 750;
int dishLoading = 1;
int countOfDishes = 0;
int countOfPots = 0;

while (amountOfDetergent >= 0)
{
    string input = Console.ReadLine();
    if (input == "End")
    {
        break;
    }
    int amountOfDishes = int.Parse(input);
    if (dishLoading % 3 == 0)
    {
        amountOfDetergent -= amountOfDishes * 15;
        countOfPots += amountOfDishes;
    }
    else
    {
        amountOfDetergent -= amountOfDishes * 5;
        countOfDishes += amountOfDishes;
    }
    dishLoading++;
}

if (amountOfDetergent >= 0)
{
    Console.WriteLine("Detergent was enough!");
    Console.WriteLine($"{countOfDishes} dishes and {countOfPots} pots were washed.");
    Console.WriteLine($"Leftover detergent {amountOfDetergent} ml.");
}
else
{
    Console.WriteLine($"Not enough detergent, {Math.Abs(amountOfDetergent)} ml. more necessary!");
}