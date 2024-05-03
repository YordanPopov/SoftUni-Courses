namespace _01.FreezingWeather
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int temperature = int.Parse(Console.ReadLine());

            string result = (temperature <= 0) ? "Freezing weather!" : "";
            Console.WriteLine(result);
        }
    }
}