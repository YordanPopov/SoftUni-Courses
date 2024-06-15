namespace test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(CalculateFibonacci(n);

        }
        static int CalculateFibonacci(int n)
        {
            if (n <= 1)
            {
                return n;
            }

            return CalculateFibonacci(n - 1) + CalculateFibonacci(n - 2);
        }
    }
}