namespace _01.SumFactorialEvenDigits
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int sumOfFactorials = 0;

            while (number > 0)
            {
                int digit = number % 10;

                if (digit % 2 == 0)
                {
                    int factorialOfCurrentDigit = GetFactorial(digit);
                    sumOfFactorials += factorialOfCurrentDigit;
                }

                number /= 10;
            }

            Console.WriteLine(sumOfFactorials);
        }

        static int GetFactorial(int digit)
        {
            int factorial = 1;

            for (int i = digit; i >= 1; i--)
            {
                factorial *= i;
            }

            return factorial;
        }
    }
}