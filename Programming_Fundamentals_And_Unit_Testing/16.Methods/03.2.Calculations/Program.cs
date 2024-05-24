namespace _03._2.Calculations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string operation = Console.ReadLine();
            double firstNumber = double.Parse(Console.ReadLine());
            double secondNumber = double.Parse(Console.ReadLine());

            if (operation == "add")
            {
                AddResult(firstNumber, secondNumber);
            }
            else if (operation == "multiply")
            {
                MultiplyResult(firstNumber, secondNumber);
            }
            else if (operation == "subtract")
            {
                SubtractResult(firstNumber, secondNumber);
            }
            else if (operation == "divide")
            {
                DivideResult(firstNumber, secondNumber);    
            }

        }

        static void AddResult(double x, double y)
        {
            double result = x + y;
            Console.WriteLine(result);
        }

        static void MultiplyResult (double x, double y)
        {
            double result = x * y;
            Console.WriteLine(result);
        }

        static void SubtractResult(double x, double y)
        {
            double result = x - y;
            Console.WriteLine(result);
        }

        static void DivideResult(double x, double y)
        {
            double result = x /y;
            Console.WriteLine(result);
        }
    }
}