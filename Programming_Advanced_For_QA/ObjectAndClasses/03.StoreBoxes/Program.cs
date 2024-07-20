using System.Security.Cryptography.X509Certificates;

namespace _03.StoreBoxes
{
    internal class Program
    {
        public class Item
        {
            public string Name { get; set; }

            public decimal Price { get; set; }

            public Item(string name, decimal price)
            {
                Name = name;
                Price = price;
            }
        }
        public class Box
        {
            public string SerialNumber { get; set; }

            public Item Item { get; set; }

            public int ItemQuantity { get; set; }

            public decimal BoxPrice { get; set; }

            public Box(string serialNumber, Item item, int itemQuantity)
            {
                SerialNumber = serialNumber;
                Item = item;
                ItemQuantity = itemQuantity;
                BoxPrice = item.Price * itemQuantity;
            }
        }
        static void Main(string[] args)
        {
            List<Box> boxes = new();

            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            while (input[0] != "end")
            {
                string serialNumber = input[0];
                string itemName = input[1];
                int itemQuantity = int.Parse(input[2]);
                decimal itemPrice = decimal.Parse(input[3]);

                Item currentItem = new Item(itemName, itemPrice);
                Box currentBox = new Box(serialNumber, currentItem, itemQuantity);

                boxes.Add(currentBox);

                input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            List<Box> orderedBoxes = boxes.OrderByDescending(b => b.BoxPrice).ToList();

            foreach (Box box in orderedBoxes)
            {
                Console.WriteLine($"{box.SerialNumber}");
                Console.WriteLine($"-- {box.Item.Name} - ${box.Item.Price:F2}: {box.ItemQuantity}");
                Console.WriteLine($"-- ${box.BoxPrice:F2}");
            }
        }
    }
}