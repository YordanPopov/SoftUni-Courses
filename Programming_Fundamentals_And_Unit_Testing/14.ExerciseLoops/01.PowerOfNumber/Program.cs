using System.Diagnostics.CodeAnalysis;

namespace _01.PowerOfNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine()),
                p = int.Parse(Console.ReadLine()),
                result = 1;
            for (int i = 0; i < p; i++)
            {
                result *= n;
            }
            Console.WriteLine(result);
        }
    }
}