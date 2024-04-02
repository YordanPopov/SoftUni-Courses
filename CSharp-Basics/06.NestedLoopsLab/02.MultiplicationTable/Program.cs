using System;

public class Program
{
    public static void Main()
    {
        int result = 0;
        for (int x = 1; x <= 10; x++)
        {
            for (int y = 1; y <= 10; y++)
            {
                result = x * y;
                Console.WriteLine("{0} * {1} = {2}", x, y, result);
            }
        }
    }
}