using System.Numerics;

namespace _08.MultiplicationSign
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());

            if (isPositiveProduct(num1, num2, num3))
            {
                Console.WriteLine("positive");
            }
            else if (isNegativeProduct(num1, num2, num3))
            {
                Console.WriteLine("negative");
            }
            else
            {
                Console.WriteLine("zero");
            }
        }

        static bool isNegativeProduct(int x1, int x2, int x3)
        {
            return (x1 < 0) || (x2 < 0) || (x3 < 0);
        }

        static bool isPositiveProduct(int x1, int x2, int x3)
        {
            return (x1 > 0) && (x2 > 0) && (x3 > 0) ||
                   (x1 > 0) && (x2 < 0) && (x3 < 0) ||
                   (x2 > 0) && (x1 < 0) && (x3 < 0) ||
                   (x3 > 0) && (x2 < 0) && (x1 < 0);
        }
    }
}