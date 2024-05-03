namespace _02.EvenOrOdd
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            string result = (number % 2 == 0) ? "even" : "odd";
            Console.WriteLine(result);
        }
    }
}