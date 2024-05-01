namespace _04.Tiles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Inputs
            double bathroomWidth = double.Parse(Console.ReadLine());
            double bathroomHeight = double.Parse(Console.ReadLine());
            double tileWidth = double.Parse(Console.ReadLine());
            double tileHeight = double.Parse(Console.ReadLine());
            // Calculations
            double bathroomArea = bathroomHeight * bathroomWidth;
            double tileArea = tileWidth * tileHeight;   
            double surplus = 1.1; // 10%
            double neededTiles = (bathroomArea * surplus) / tileArea;
            // Output
            Console.WriteLine($"{Math.Round(neededTiles)}");
        }
    }
}