namespace _02.MiddleElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            double num1 = numbers[numbers.Length / 2 - 1];
            double num2 = numbers[numbers.Length / 2];
            double averageSum = (num1 + num2) / 2;

            Console.WriteLine($"{averageSum:F2}");
        }
    }
}