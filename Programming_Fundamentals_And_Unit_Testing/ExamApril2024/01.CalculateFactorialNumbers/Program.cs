namespace _01.CalculateFactorialNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
           int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());
                PrintFactorial(currentNumber);
            }
        }

        static void PrintFactorial(int number)
        {
            int result = 1;

            for (int i = number; i > 0; i--)
            {
                result *= i;
            }

            Console.WriteLine(result);
        }
    }
}