namespace _07.SuppliesForSchool
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Inputs
            int numberOfPackegesOfPens = int.Parse(Console.ReadLine());
            int numberOfPacketsOfMarkers = int.Parse(Console.ReadLine());
            int litersOfBoardCleaner = int.Parse(Console.ReadLine());
            double discountPercentage = double.Parse(Console.ReadLine()) / 100;

            // Calculations
            double allMaterialPrice = (numberOfPackegesOfPens * 5.80) + (numberOfPacketsOfMarkers * 7.20) + (litersOfBoardCleaner * 1.20);
            double priceAfterDiscount = allMaterialPrice - (allMaterialPrice * discountPercentage);

            // Output
            Console.WriteLine($"{priceAfterDiscount}");
        }
    }
}