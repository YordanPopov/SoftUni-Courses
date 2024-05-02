namespace _05.BasketballEquipment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Input
            int trainingFee = int.Parse(Console.ReadLine());

            // Calculations
            double basketballSneakersPrice = trainingFee - (trainingFee * 0.4);
            double basketballTeam = basketballSneakersPrice - (basketballSneakersPrice * 0.2);
            double basketballPrice = basketballTeam * 0.25;
            double basketballAccessories = basketballPrice * 0.2;
            double totalCost = basketballSneakersPrice + basketballTeam + basketballPrice + basketballAccessories + trainingFee;

            // Output
            Console.WriteLine(totalCost);
        }
    }
}