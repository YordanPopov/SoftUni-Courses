namespace _08.FruitOrVeg
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string productType = Console.ReadLine();
            bool isFruit = (productType == "banana") ||
                           (productType == "apple") ||
                           (productType == "kiwi") ||
                           (productType == "cherry") ||
                           (productType == "lemon"),
                 isVegetable = (productType == "cucumber") ||
                               (productType == "pepper") ||
                               (productType == "carrot");
            string result = (isFruit) ? "fruit" : (isVegetable) ? "vegetable" : "unknown";
            Console.WriteLine(result);
        }
    }
}