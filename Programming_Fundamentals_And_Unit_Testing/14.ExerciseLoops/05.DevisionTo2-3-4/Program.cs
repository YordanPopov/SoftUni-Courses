namespace _05.DevisionTo2_3_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double divisibleBy2 = 0.0,
                   divisibleBy3 = 0.0,
                   divisibleBy4 = 0.0;

            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                if (number % 2 == 0) divisibleBy2++;
                if (number % 3 == 0) divisibleBy3++;
                if (number % 4 == 0) divisibleBy4++;
            }
            Console.WriteLine($"{divisibleBy2 / n * 100.0:f2}%");
            Console.WriteLine($"{divisibleBy3 / n * 100.0:f2}%");
            Console.WriteLine($"{divisibleBy4 / n * 100.0:f2}%");
        }
    }
}