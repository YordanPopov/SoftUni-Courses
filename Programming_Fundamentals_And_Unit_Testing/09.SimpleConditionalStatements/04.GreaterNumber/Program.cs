using System.Threading.Channels;

namespace _04.GreaterNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());

            int greaterNumber = (firstNumber > secondNumber) ? firstNumber : secondNumber;
            Console.WriteLine($"Greater number: {greaterNumber}");
        }
    }
}