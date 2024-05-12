namespace _08.AccountBalance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            double balance = 0.0;

            while (input != "End")
            {
                double money = double.Parse(input);
                if (money > 0)
                {
                    Console.WriteLine($"Increase: {Math.Abs(money):f2}");
                    balance += money;
                }else
                {
                    Console.WriteLine($"Decrease: {Math.Abs(money):f2}");
                    balance += money;
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"Balance: {balance:f2}");
        }
    }
}