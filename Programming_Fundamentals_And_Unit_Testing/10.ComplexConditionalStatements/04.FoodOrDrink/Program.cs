namespace _04.FoodOrDrink
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Input
            string productName = Console.ReadLine();

            // Calculations
            bool isFood = productName == "curry" ||
                          productName == "noodles" ||
                          productName == "sushi" ||
                          productName == "spaghetti" ||
                          productName == "bread";
            bool isDrink = productName == "tea" ||
                           productName == "water" ||
                           productName == "coffee" ||
                           productName == "juice";
            string result = (isFood) ? "food" : (isDrink) ? "drink" : "unknown";
            Console.WriteLine(result);
        }
    }
}