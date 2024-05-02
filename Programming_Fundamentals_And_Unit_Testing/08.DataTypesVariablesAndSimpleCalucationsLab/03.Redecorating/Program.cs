namespace _03.Redecorating
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Inputs
            int amountOfNylon = int.Parse(Console.ReadLine());
            int amountOfPaint = int.Parse(Console.ReadLine());
            int quantityOfThinner = int.Parse(Console.ReadLine());
            int hoursToDoTheWork = int.Parse(Console.ReadLine());

            // Calculations
            double nylonCost = (amountOfNylon + 2) * 1.50;
            double paintCost = (amountOfPaint + (amountOfPaint * 0.1)) * 14.50;
            double thinnerCost = quantityOfThinner * 5;
            double totalMaterialCost = nylonCost + paintCost + thinnerCost + 0.40;
            double craftsmenCost = (totalMaterialCost * 0.3) * hoursToDoTheWork;
            double totalCost = totalMaterialCost + craftsmenCost;
            
            // Outputs
            Console.WriteLine(totalCost);
        }
    }
}