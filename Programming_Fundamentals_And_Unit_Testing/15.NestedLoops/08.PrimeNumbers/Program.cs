namespace _08.PrimeNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int startingNumber = int.Parse(Console.ReadLine());
            int endingNumber = int.Parse(Console.ReadLine());

            while (startingNumber <= endingNumber)
            {
                bool isPrime = true;
                for (int i = 2; i <= Math.Sqrt(startingNumber); i++)
                {
                    if (startingNumber % i == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime)
                {
                    Console.Write(startingNumber + " ");
                }
                startingNumber++;
            }
        }
    }
}