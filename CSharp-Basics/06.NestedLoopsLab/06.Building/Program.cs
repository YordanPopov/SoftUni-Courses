using System;

public class Program
{
    public static void Main()
    {
        int floors = int.Parse(Console.ReadLine());
        int rooms = int.Parse(Console.ReadLine());

        for (int x = floors; x > 0; x--)
        {
            if (x == floors)
            {
                for (int y = 0; y < rooms; y++)
                {
                    Console.Write("L{0}{1} ", x, y);
                }
                Console.WriteLine();
            }
            else if (x % 2 == 0)
            {
                for (int y = 0; y < rooms; y++)
                {
                    Console.Write("O{0}{1} ", x, y);
                }
                Console.WriteLine();
            }
            else
            {
                for (int y = 0; y < rooms; y++)
                {
                    Console.Write("A{0}{1} ", x, y);
                }
                Console.WriteLine();
            }
        }

        //Console.WriteLine("Hello World");
    }
}