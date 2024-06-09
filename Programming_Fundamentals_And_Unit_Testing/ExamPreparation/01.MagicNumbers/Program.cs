namespace _01.MagicNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            bool isHasOutput = false;

            for (int i = 1; i <= n; i++)
            {
                int sumOfDigits = 0;
                bool isAllDigitsPrime = true;
                int currentNumber = i;

                while (currentNumber > 0)
                {
                    int digit = currentNumber % 10;

                    if (isPrime(digit))
                    { 
                        sumOfDigits += digit;
                    }
                    else
                    {
                        isAllDigitsPrime = false;
                        break;
                    }

                    currentNumber /= 10;
                }

                if (isAllDigitsPrime && sumOfDigits % 2 == 0)
                {
                    Console.Write($"{i} ");
                    isHasOutput = true;
                }
            }
            if (!isHasOutput)
            {
                Console.WriteLine("no");
            }
        }
        static bool isPrime(int number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            for (int i = 3; i <= Math.Sqrt(number); i += 2)
            {
                if (number % i == 0) return false;
            }

            return true;
        }
    }
}