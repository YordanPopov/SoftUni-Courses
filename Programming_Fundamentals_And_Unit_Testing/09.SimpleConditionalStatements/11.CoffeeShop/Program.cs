namespace _11.CoffeeShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Input
            string drinkName = Console.ReadLine();
            string extra = Console.ReadLine();

            // Calculations
            double price = 0.0;
            double finalPrice = drinkName switch
            {
                "coffee" => price += 1.00,
                "tea" => price += 0.60
            };
            finalPrice = extra switch
            {
                "sugar" => finalPrice += 0.40,
                "no" => finalPrice = finalPrice
            };
            // Output
            Console.WriteLine($"Final price: ${finalPrice:f2}");
        }
    }
}