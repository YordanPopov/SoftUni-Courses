namespace Problem02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] stocks = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int startIndex = int.Parse(Console.ReadLine());
            int endIndex = int.Parse(Console.ReadLine());
            int stockSum = 0;
            int counter = 0;

            for (int i = startIndex; i <= endIndex; i++)
            {
                stockSum += stocks[i];
                counter++;
            }

            
            double averagePrice = (double)stockSum / counter;
            Console.WriteLine($"{averagePrice:F2}");
        }
    }
}