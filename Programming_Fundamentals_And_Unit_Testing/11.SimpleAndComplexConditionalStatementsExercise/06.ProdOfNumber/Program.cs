namespace _06.ProdOfNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Input
            double num1 = double.Parse(Console.ReadLine()),
                   num2 = double.Parse(Console.ReadLine()),
                   num3 = double.Parse(Console.ReadLine());

            // Calculations
            bool isPositive = (num1 > 0) && (num2 > 0) && (num3 > 0) ||
                              (num1 > 0) && (num2 < 0) && (num3 < 0) ||
                              (num2 > 0) && (num1 < 0) && (num3 < 0) ||
                              (num3 > 0) && (num1 < 0) && (num2 < 0),
                 isNegative = (num1 < 0) || (num2 < 0) || (num3 < 0);
            string result = (isPositive) ? "positive" : (isNegative) ? "negative" : "zero";

            // Output
            Console.WriteLine(result);
        }
    }
}