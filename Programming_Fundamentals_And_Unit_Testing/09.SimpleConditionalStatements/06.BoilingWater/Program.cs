namespace _06.BoilingWater
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int waterTemperature = int.Parse(Console.ReadLine());

            string result = (waterTemperature > 100) ? "The water is boiling" : "The water is not hot enough";
            Console.WriteLine(result);
        }
    }
}