namespace _05.DepositCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Inputs
            double depositedAmount = double.Parse(Console.ReadLine());
            int termOfDeposit = int.Parse(Console.ReadLine());
            double annualInterestRate = double.Parse(Console.ReadLine()) / 100;
            
            // Calculations
            double amount = depositedAmount + termOfDeposit * (depositedAmount * annualInterestRate) / 12;

            // Outputs
            Console.WriteLine($"{amount:f2}");
        }
    }
}