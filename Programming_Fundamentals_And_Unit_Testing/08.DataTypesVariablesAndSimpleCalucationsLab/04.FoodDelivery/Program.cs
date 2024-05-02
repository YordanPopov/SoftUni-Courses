namespace _04.FoodDelivery
{
    internal class Program
    {
        static void Main(string[] args)
        {
           // Inputs
           int numberOfChickenMenus = int.Parse(Console.ReadLine());
           int numberOFishMenus = int.Parse(Console.ReadLine());
           int numberOfVegetarianMenus = int.Parse(Console.ReadLine());

            // Calculations
            double menusCost = (numberOfChickenMenus * 10.35) + (numberOFishMenus * 12.40) + (numberOfVegetarianMenus * 8.15);
            double dessertPrice = menusCost * 0.2;
            double orderPrice = menusCost + dessertPrice + 2.50;

            // Output
            Console.WriteLine(orderPrice);
        }
    }
}