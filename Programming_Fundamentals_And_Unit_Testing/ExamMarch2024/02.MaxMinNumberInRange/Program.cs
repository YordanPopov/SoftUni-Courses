namespace _02.MaxMinNumberInRange
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int startIndex = int.Parse(Console.ReadLine());
            int endIndex = int.Parse(Console.ReadLine());

            int minNumber = int.MaxValue;
            int maxNumber = int.MinValue;

            for (int i = startIndex; i <= endIndex; i++)
            {

                if (numbers[i] <= minNumber)
                {
                    minNumber = numbers[i];
                }

                if (numbers[i] >= maxNumber)
                {
                    maxNumber = numbers[i];
                }
            }

            int sumOfNumber = minNumber + maxNumber;
            Console.WriteLine(sumOfNumber);
        }
    }
}