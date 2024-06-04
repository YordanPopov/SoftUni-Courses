using System;

namespace _05.BombNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> bombNumbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int bombNum = bombNumbers[0];
            int pow = bombNumbers[1];

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] == bombNum)
                {
                    int startIndex = i - pow;
                    int range = pow + pow + 1;

                    if (startIndex < 0)
                    {
                        range += startIndex;
                        startIndex = 0;
                    }

                    if (startIndex + range > numbers.Count)
                    {
                        range = numbers.Count - startIndex;
                    }

                    numbers.RemoveRange(startIndex, range);
                    i = -1;
                }
                
            }

            Console.WriteLine($"{numbers.Sum()}");
        }
    }
}