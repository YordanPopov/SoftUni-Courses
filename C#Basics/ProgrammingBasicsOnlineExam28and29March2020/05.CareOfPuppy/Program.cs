int dogFood = int.Parse(Console.ReadLine()) * 1000;

string eatenFood = Console.ReadLine();
int totalEatenFood = 0;
bool isEnough = true;

while (eatenFood != "Adopted")
{
    int eatenFoodByDog = int.Parse(eatenFood);
    totalEatenFood += eatenFoodByDog;

    if (totalEatenFood > dogFood)
    {
        isEnough = false;
        
    }



    eatenFood = Console.ReadLine();
}

if (isEnough)
{
    Console.WriteLine($"Food is enough! Leftovers: {dogFood - totalEatenFood} grams.");
}else
{
    Console.WriteLine($"Food is not enough. You need {totalEatenFood - dogFood} grams more.");
}