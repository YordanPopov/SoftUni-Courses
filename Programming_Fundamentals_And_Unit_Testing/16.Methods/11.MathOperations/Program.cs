namespace _11.MathOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double firstNumber = double.Parse(Console.ReadLine());  
            char command = char.Parse(Console.ReadLine());
            double secondNumber = double.Parse(Console.ReadLine());

            Console.WriteLine(GetResult(firstNumber, command, secondNumber));
        }

        static double GetResult(double x, char command, double y)
        {
            double result = command switch
            {
                '+' => x + y,
                '-' => x - y,
                '*' => x * y,
                '/' => x / y
            };
            return result;
        }
    }
}