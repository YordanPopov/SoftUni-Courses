namespace _06.MathPower
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int baseNumber = int.Parse(Console.ReadLine());
            int powerNumber = int.Parse(Console.ReadLine());
          //Console.WriteLine(MathPower(baseNumber, powerNumber));
            Console.WriteLine(MathPowerloop(baseNumber, powerNumber));
        }

        static double MathPower(double tempBase, double tempPower)
        {
            double result = Math.Pow(tempBase, tempPower);
            return result;
        }
        static int MathPowerloop(int tempBase, int tempPower)
        {
            int result = 1;
            for (int i = 1; i <= tempPower; i++)
            {
                result *= tempBase;
            }
            return result;
        }
    }
}