namespace _07.SumOfDigits
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int sum = 0;

            while (input != "End")
            {
                int number = int.Parse(input);
                while (number > 0)
                {
                    int digit = number % 10;
                    sum += digit;
                    number /= 10;
                }
                Console.WriteLine($"Sum of digits = {sum}");
                sum = 0;
                input = Console.ReadLine();
            }
            Console.WriteLine("Goodbye");
        }
    }
}