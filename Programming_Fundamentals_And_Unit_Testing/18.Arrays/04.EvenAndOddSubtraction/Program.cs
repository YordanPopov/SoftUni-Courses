namespace _04.EvenAndOddSubtraction
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
            int oddSum = 0;

            foreach (int currentNumber in numbers)
            {
                if (currentNumber % 2 == 0)
                {
                    evenSum += currentNumber;
                }
                else
                {
                    oddSum += currentNumber;
                }
            }

            int diff = evenSum - oddSum;
            Console.WriteLine(diff);
        }
    }
}