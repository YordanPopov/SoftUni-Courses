namespace _03.UniquePINCodes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int max1 = int.Parse(Console.ReadLine());
            int max2 = int.Parse(Console.ReadLine());
            int max3 = int.Parse(Console.ReadLine());

            for (int firstDigit = 2; firstDigit <= max1; firstDigit += 2)
            {
                for (int secondDigit = 1; secondDigit <= max2; secondDigit++)
                {
                    for (int thirdDigit = 2; thirdDigit <= max3; thirdDigit += 2)
                    {
                        if (IsPrimeNumber(secondDigit))
                        {
                            Console.WriteLine("{0}{1}{2}", firstDigit, secondDigit, thirdDigit);
                        }
                    }
                }
            }
        }
        static bool IsPrimeNumber(int number)
        {
            bool isPrime = true;
            if (number <= 1)
            {
                isPrime = false;
            }
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }
            return isPrime;
        }
    }
}
