using System;

public class Program
{
    public static void Main()
    {
        int startingNumber = int.Parse(Console.ReadLine());
        int finalNumber = int.Parse(Console.ReadLine());
        int magicNumber = int.Parse(Console.ReadLine());
        int combinations = 0;
        int result = 0;
        bool isHaveCombination = false;
        for (int x = startingNumber; x <= finalNumber; x++)
        {
            for (int y = startingNumber; y <= finalNumber; y++)
            {
                combinations++;
                result = x + y;
                if (result == magicNumber)
                {
                    Console.WriteLine("Combination N:{0} ({1} + {2} = {3})", combinations, x, y, magicNumber);
                    isHaveCombination = true;
                    break;
                }
            }
            if (isHaveCombination)
            {
                break;
            }
        }
        if (!isHaveCombination)
        {
            Console.WriteLine("{0} combinations - neither equals {1}", combinations, magicNumber);
        }

    }
}