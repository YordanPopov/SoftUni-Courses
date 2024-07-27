using System.Runtime.CompilerServices;

namespace _02.EnterNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();

            int prevNum = 1;

            while (numbers.Count < 10)
            {        
                try
                {
                    int currentNumber = ReadNumber(prevNum, 100);

                    numbers.Add(currentNumber);

                    prevNum = currentNumber;
                }
                catch(ArgumentException)
                {
                    Console.WriteLine($"Your number is not in range {prevNum} - 100!");
                    
                }
                catch(FormatException)
                {
                    Console.WriteLine("Invalid Number!");
                }  
 
            }

            Console.WriteLine(String.Join(", ", numbers));
        }

        static int ReadNumber(int start, int end)
        {
            int number = int.Parse(Console.ReadLine());

            if (start >= number || number >= end)
            {
                throw new ArgumentException();
            }

            return number;
        }
    }
}