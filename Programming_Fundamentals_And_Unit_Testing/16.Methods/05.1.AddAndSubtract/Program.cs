namespace _05._1.AddAndSubtract
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int thirdNumber = int.Parse(Console.ReadLine());
            int sum = GetSum(firstNumber, secondNumber);
            Console.WriteLine(GetSubtractResult(thirdNumber, sum));
        }

        static int GetSum(int firstNumber, int secondNumber)
        {
            return firstNumber + secondNumber;
        }
        
        static int GetSubtractResult(int number, int sum)
        {
            return sum - number;
        }
    }
}