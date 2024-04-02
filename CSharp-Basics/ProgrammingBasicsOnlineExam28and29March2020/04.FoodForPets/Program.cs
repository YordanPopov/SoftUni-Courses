
        int days = int.Parse(Console.ReadLine());
        double totalFood = double.Parse(Console.ReadLine());

        double totalBiscuits = 0;
        double totalEatenFood = 0;
        double totalDogFood = 0;
        double totalCatFood = 0;

        for (int day = 1; day <= days; day++)
        {
            int dogFood = int.Parse(Console.ReadLine());
            int catFood = int.Parse(Console.ReadLine());

            totalDogFood += dogFood;
            totalCatFood += catFood;
            totalEatenFood += dogFood + catFood;

            if (day % 3 == 0)
            {
                double biscuits = 0.1 * (dogFood + catFood);
                totalBiscuits += biscuits;
            }
        }

        double percentageEatenFood = (totalEatenFood / totalFood) * 100;
        double percentageDogFood = (totalDogFood / totalEatenFood) * 100;
        double percentageCatFood = (totalCatFood / totalEatenFood) * 100;

        Console.WriteLine($"Total eaten biscuits: {Math.Round(totalBiscuits)}gr.");
        Console.WriteLine($"{percentageEatenFood:F2}% of the food has been eaten.");
        Console.WriteLine($"{percentageDogFood:F2}% eaten from the dog.");
        Console.WriteLine($"{percentageCatFood:F2}% eaten from the cat.");
