namespace Problem01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            if (n <= 0)
            {
                Console.WriteLine("0");
            }

            int caloricSum = 0;

            for (int i = 0; i < n; i++)
            {
                int caloricValue = int.Parse(Console.ReadLine());
                caloricSum += caloricValue;
                Console.WriteLine(caloricSum);
            }
        }
    }
}