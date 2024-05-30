namespace _07.FactorialDivision
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());

            int firstNumberFactorial = GetFactorial(firstNumber);
            int secondNumberFactorial = GetFactorial(secondNumber);
            int result = firstNumberFactorial / secondNumberFactorial;
            Console.WriteLine(result);

        }

        static int GetFactorial(int number)
        {
            int factorial = 1;

            for (int i = number; i > 0; i--)
            {
                factorial *= i;
            }
            return factorial;
        }
    }
}