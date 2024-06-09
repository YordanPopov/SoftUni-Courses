namespace _02.MinMaxValues
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int n = int.Parse(Console.ReadLine());

            int maxNumber = int.MinValue;
            int minNumber = int.MaxValue;

            for (int i = 0; i < n; i++)
            {
                if (numbers[i] >= maxNumber)
                {
                    maxNumber = numbers[i];
                }
                if (numbers[i] <= minNumber)
                {
                    minNumber = numbers[i];
                }
            }

            Console.WriteLine(maxNumber);
            Console.WriteLine(minNumber);
        }
    }
}