namespace _03.Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Dictionary<string, (double Price, int Quantity)> products = new();

            while (input[0] != "buy")
            {
                string name = input[0];
                double price = double.Parse(input[1]);
                int quantity = int.Parse(input[2]);

                if (products.ContainsKey(name))
                {
                    products[name] = (price, products[name].Quantity + quantity);
                }
                else
                { 
                    products[name] = (price, quantity);
                }

                input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToList();
            }

            foreach (var product in products)
            {
                string name = product.Key;
                double price = product.Value.Price;
                int quantity = product.Value.Quantity;
                double totalPrice = price * quantity;

                Console.WriteLine($"{name} -> {totalPrice:F2}");
            }

            // Another Solution

            //Dictionary<string, List<decimal>> products = new();

            //string input = Console.ReadLine();

            //while (input != "buy")
            //{
            //    string[] inputArray = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            //    string productName = inputArray[0];
            //    decimal price = decimal.Parse(inputArray[1]);
            //    decimal quantity = decimal.Parse(inputArray[2]);

            //    if (!products.ContainsKey(productName))
            //    {
            //        products.Add(productName, new List<decimal>() { price, quantity});

            //    }
            //    else
            //    {
            //        products[productName][0] = price;
            //        products[productName][1] += quantity;
            //    }

            //    input = Console.ReadLine();
            //}

            //foreach (KeyValuePair<string, List<decimal>> currentProduct in products)
            //{
            //    string currentProductName = currentProduct.Key;
            //    decimal currentProductPrice = currentProduct.Value[0];
            //    decimal currentProductQuantity = currentProduct.Value[1];

            //    decimal currentProductAmount = currentProductPrice * currentProductQuantity;

            //    Console.WriteLine($"{currentProductName} -> {currentProductAmount:F2}");
            //}
        }
    }
}