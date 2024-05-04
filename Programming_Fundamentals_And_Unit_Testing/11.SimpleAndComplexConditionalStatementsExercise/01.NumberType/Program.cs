namespace _01.NumberType
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            string result = (number > 0) ? "positive" : (number < 0) ? "negative" : "zero";
            Console.WriteLine(result);
        }
    }
}