using System;

public class Program
{
    public static void Main()
    {
        string number = Console.ReadLine();
        int sumPrimeNumbers = 0;
        int sumNonPrimeNumbers = 0;

        while (number != "stop")
        {
            int currentNumber = int.Parse(number);
            bool isPrime = true;
            bool isNegative = false;

            if (currentNumber < 0)
            {
                Console.WriteLine("Number is negative.");
                isNegative = true;
            }
            if (!isNegative)
            {
                if (currentNumber >= 0 && currentNumber <= 1)
                {
                    isPrime = false;
                }
                for (int i = 2; i <= Math.Sqrt(currentNumber); i++)
                {
                    if (currentNumber % i == 0)
                    {
                        isPrime = false;
                    }
                }
                if (isPrime)
                {
                    sumPrimeNumbers += currentNumber;
                }
                else
                {
                    sumNonPrimeNumbers += currentNumber;
                }
            }
            number = Console.ReadLine();
        }
        Console.WriteLine("Sum of all prime numbers is: {0}", sumPrimeNumbers);
        Console.WriteLine("Sum of all non prime numbers is: {0}", sumNonPrimeNumbers);
        //Console.WriteLine("Hello World");
    }
}