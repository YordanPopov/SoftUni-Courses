using System;

public class Program
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int minNumber = int.MaxValue;
        int maxNumber = int.MinValue;

        for (int i = 0; i <= n - 1; i++)
        {
            int num = int.Parse(Console.ReadLine());
            if (num > maxNumber)
            {
                maxNumber = num;
            }
            if (num < minNumber)
            {
                minNumber = num;
            }
        }
        Console.WriteLine("Max number: {0}", maxNumber);
        Console.WriteLine("Min number: {0}", minNumber);
    }
}