namespace _01.SignOfIntegerNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            PrintSign(number);
        }

        static void PrintSign(int number)
        {
            string result = (number > 0) ? $"The number {number} is positive." :
                            (number < 0) ? $"The number {number} is negative." : $"The number {number} is zero.";
            Console.WriteLine(result);
        }
    }
}