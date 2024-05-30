namespace _02.MagicNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            for (int firstDigit = 1; firstDigit <= 9; firstDigit++)
            {
                for (int secondDigit = 0; secondDigit <= 9; secondDigit++)
                {
                    for (int thirdDigit = 0; thirdDigit <= 9; thirdDigit++)
                    {
                        int productOfDigits = firstDigit * secondDigit * thirdDigit;
                        if (productOfDigits == number)
                        {
                            Console.Write("{0}{1}{2} ", firstDigit, secondDigit, thirdDigit);
                        }
                    }
                }
            }
        }
    }
}