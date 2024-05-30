namespace _01.StupidPassword
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            for (int firstDigit = 2; firstDigit <= number; firstDigit += 2)
            {
                for (int secondDigit = 1; secondDigit <= number; secondDigit += 2)
                {                  
                    Console.Write($"{firstDigit}{secondDigit}{firstDigit * secondDigit} ");    
                }
            }
        }
    }
}