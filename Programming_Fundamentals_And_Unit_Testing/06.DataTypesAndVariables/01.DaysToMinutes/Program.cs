namespace _01.DaysToMinutes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfDays = int.Parse(Console.ReadLine());
            int minutes = numberOfDays * 24 * 60;
            Console.WriteLine($"Minutes = {minutes}");
        }
    }
}