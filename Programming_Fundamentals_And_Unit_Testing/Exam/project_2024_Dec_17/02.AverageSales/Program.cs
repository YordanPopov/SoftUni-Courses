namespace _02.AverageSales
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dailySales = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int startIndex = int.Parse(Console.ReadLine());
            int endIndex = int.Parse(Console.ReadLine());

            double totalSales = 0;
            int counter = 0;

            for (int i = startIndex; i <= endIndex; i++)
            {
                totalSales += dailySales[i];
                counter++;
            }

            double avrSales = totalSales / counter;
            Console.WriteLine($"{avrSales:F2}");
        }
    }
}