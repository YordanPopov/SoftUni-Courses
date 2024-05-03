namespace _07.SpeedInfo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double speed = double.Parse(Console.ReadLine());

            string result = (speed > 30) ? "Fast" : "Slow";
            Console.WriteLine(result);
        }
    }
}