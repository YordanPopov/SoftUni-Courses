namespace _08._1.FactorialDevision
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double firstNumber = int.Parse(Console.ReadLine());
            double secondNumber = int.Parse(Console.ReadLine());

            double firstFactorial = FactorialResult(firstNumber);
            double secondFactorial = FactorialResult(secondNumber);
            Console.WriteLine($"{firstFactorial / secondFactorial:F2}");

        }

        static double FactorialResult(double number)
        {
            double result = 1;
            for (int i = (int)number; i >= 1; i--)
            {
                result *= i;
            }

            return result;
        }
    }
}