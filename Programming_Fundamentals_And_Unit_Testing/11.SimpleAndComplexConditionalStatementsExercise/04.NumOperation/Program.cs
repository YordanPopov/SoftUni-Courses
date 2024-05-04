namespace _04.NumOperation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double num1 = double.Parse(Console.ReadLine()),
                   num2 = double.Parse(Console.ReadLine());
            string mathOperator = Console.ReadLine();
            double result = mathOperator switch
            {
                "+" => num1 + num2,
                "-" => num1 - num2,
                "*" => num1 * num2,
                "/" => num1 / num2
            };
            Console.WriteLine($"{num1} {mathOperator} {num2} = {result:f2}");
        }
    }
}