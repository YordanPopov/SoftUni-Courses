namespace _02.CenturiesToMinutes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Input
            int century = int.Parse(Console.ReadLine());

            // Calculations
            int years = century * 100;
            double days = Math.Floor(years * 365.2422);
            double hours = days * 24;
            double minutes = hours * 60;

            // Otput
            Console.WriteLine($"{century} centuries = {years} years = {days} days = {hours} hours = {minutes} minutes");
        }
    }
}