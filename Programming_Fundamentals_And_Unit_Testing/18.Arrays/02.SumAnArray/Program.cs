namespace _02.SumAnArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                            .Split()
                            .Select(int.Parse)
                            .ToArray();

            int sum = 0;

            foreach (int currentNumber in numbers)
            {
                sum += currentNumber;
            }

            Console.WriteLine(sum);                 
        }
    }
}