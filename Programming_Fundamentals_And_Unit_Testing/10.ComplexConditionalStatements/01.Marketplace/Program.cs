namespace _01.Marketplace
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Input
            string product = Console.ReadLine();
            string day = Console.ReadLine();

            // Calculations
            double price = 0.0;
            if (product == "Banana")
            {
                price = (day == "Weekday") ? price = 2.50 : price = 2.70;
            }else if (product == "Apple")
            {
                price = (day == "Weekday") ? price = 1.30 : price = 1.60;
            }
            else if(product == "Kiwi")
            {
                price = (day == "Weekday") ? price = 2.20 : price = 3.00;
            }

            // Output
            Console.WriteLine($"{price:f2}");
        }
    }
}