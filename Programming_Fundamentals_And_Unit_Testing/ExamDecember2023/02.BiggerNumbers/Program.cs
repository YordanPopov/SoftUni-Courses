namespace _02.BiggerNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int number = int.Parse(Console.ReadLine());

            foreach (int currentNumber in numbers)
            {

                if (currentNumber > number)
                {
                    Console.Write($"{currentNumber} ");
                }

            }
        }
    }
}