namespace _09.MaxSeaquensOfEqualElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int counter = 1;
            int longestSeaquens = 0;
            int element = 0;

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                if (numbers[i] == numbers[i + 1])
                {
                    counter++;
                }
                else
                {
                    counter = 1;
                }

                if (counter > longestSeaquens)
                {
                    longestSeaquens = counter;
                    element = numbers[i];
                }
            }
            for (int i = 0; i < longestSeaquens; i++)
            {
                Console.Write($"{element} ");
            }
        }
    }
}