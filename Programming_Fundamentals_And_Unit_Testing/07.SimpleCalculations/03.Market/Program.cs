namespace _03.Market
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double tomatoPrice = double.Parse(Console.ReadLine());
            double tomatoQuantity = double.Parse(Console.ReadLine());
            double cucumberPrice = double.Parse(Console.ReadLine());
            double cucumberQuantity = double.Parse(Console.ReadLine());
            double totalCost = (tomatoPrice * tomatoQuantity) + (cucumberQuantity * cucumberPrice);
            Console.WriteLine($"{totalCost:f2}");
        }
    }
}