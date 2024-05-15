namespace _06.TravelSaving
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string destination = Console.ReadLine();
            double sum = 0.0;

            while (destination != "End") 
            {
                double budget = double.Parse(Console.ReadLine());
                while (sum < budget) 
                {
                    double money = double.Parse(Console.ReadLine());
                    sum += money;
                    Console.WriteLine($"Collected: {sum:f2}");
                }
                Console.WriteLine($"Going to {destination}!");
                sum = 0.0;
                destination = Console.ReadLine();
            }
        }
    }
}