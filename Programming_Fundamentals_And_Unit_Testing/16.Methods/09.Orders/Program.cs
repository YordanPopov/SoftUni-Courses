namespace _09.Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string productType = Console.ReadLine();
            int productQuantity = int.Parse(Console.ReadLine());

            Console.WriteLine(GetPriceOfProduct(productType, productQuantity));
        }

        static decimal GetPriceOfProduct(string product, int quantity)
        {
            decimal productPrice = product switch
            {
                "coffee" => 1.50m,
                "water" => 1.00m,
                "coke" => 1.40m,
                "snacks" => 2.00m,
                _ => productPrice = 0m
            };
            return productPrice * quantity;
        }
    }
}