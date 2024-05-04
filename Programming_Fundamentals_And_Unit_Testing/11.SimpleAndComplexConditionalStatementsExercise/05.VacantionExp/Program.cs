namespace _05.VacantionExp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Input
            string season = Console.ReadLine(),
                   accommodationType = Console.ReadLine();
            int days = int.Parse(Console.ReadLine());

            //Calculations
            double totalPrice = 0.0;
            totalPrice = season switch
            {
                "Summer" => totalPrice = (accommodationType == "Hotel") ? (50 * days) : (accommodationType == "Camping") ? (30 * days) : totalPrice,
                "Autumn" => totalPrice = (accommodationType == "Hotel") ? (20 * days) * 0.7 : (accommodationType == "Camping") ? (15 * days) * 0.7 : totalPrice,
                "Winter" => totalPrice = (accommodationType == "Hotel") ? (40 * days) * 0.9 : (accommodationType == "Camping") ? (10 * days) * 0.9 : totalPrice,
                "Spring" => totalPrice = (accommodationType == "Hotel") ? (30 * days) * 0.8 : (accommodationType == "Camping") ? (10 * days) * 0.8 : totalPrice
            };
            // Output
            Console.WriteLine($"{totalPrice:f2}");
        }
    }
}