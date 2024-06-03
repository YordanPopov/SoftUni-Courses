namespace _05._2.SumEvenNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                                   .Split()
                                   .Select(int.Parse)
                                   .ToArray();

            int evenSum = 0;

            foreach (int currentNumber in numbers)
            {
                if (currentNumber % 2 == 0)
                {
                    evenSum += currentNumber;
                }
            }
            Console.WriteLine(evenSum);
        }
    }
}