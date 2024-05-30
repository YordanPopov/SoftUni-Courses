namespace _05.HappyNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            for (int d1 = 1; d1 <= 9; d1++)
            {
                for (int d2 = 0; d2 <= 9; d2++)
                {
                    for (int d3 = 0; d3 <= 9; d3++)
                    {
                        for (int d4 = 0; d4 <= 9; d4++)
                        {
                            if (IsHappyNumber(d1, d2, d3, d4, number))
                            {
                                Console.Write("{0}{1}{2}{3} ", d1, d2, d3, d4);
                            }
                        }
                    }
                }
            }
        }
        static bool IsHappyNumber(int a, int b, int c, int d, int number)
        {
            if (a + b == number && c + d == number)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}