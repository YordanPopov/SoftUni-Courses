using System.Security.Cryptography.X509Certificates;

namespace _01.DayOfWeek
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfDay = int.Parse(Console.ReadLine());

            string[] days =
            {
                "Monday",
                "Tuesday",
                "Wednesday",
                "Thursday",
                "Friday",
                "Saturday",
                "Sunday"
            };

            if (numberOfDay >= 1 && numberOfDay <= 7)
            {
                Console.WriteLine($"{days[numberOfDay - 1]}");
            }
            else
            {
                Console.WriteLine("Invalid day!");
            }
        }
    }
}