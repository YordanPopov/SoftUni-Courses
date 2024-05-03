namespace _09.Cinema
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string movieType = Console.ReadLine();
            int rowsCount = int.Parse(Console.ReadLine());
            int seatsPerRow = int.Parse(Console.ReadLine());

            int seatsCount = rowsCount * seatsPerRow;
            double totalPrice = 0.0;
            totalPrice = movieType switch
            {
                "Premiere" => totalPrice += seatsCount * 12.00,
                "Normal" => totalPrice += seatsCount * 7.50,
                "Discount" => totalPrice += seatsCount * 5.00
            };
            Console.WriteLine($"{totalPrice:f2}");
        }
    }
}