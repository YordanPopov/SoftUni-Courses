namespace _02.SmallerNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int n = int.Parse(Console.ReadLine());

            foreach (int currentNumber in numbers)
            {
                if (currentNumber < n)
                {
                    Console.Write($"{currentNumber} ");
                }
            }
        }
    }
}