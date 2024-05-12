namespace _06.SpecialNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            bool isSpecial = false;
            int numberCopy = number;

            while (number != 0)
            {
                int digit = number % 10;
                isSpecial = (numberCopy % digit == 0) ? true : false;
                number /= 10;
            }
            string result = (isSpecial) ? numberCopy + " is special" : numberCopy + " is not special";
            Console.WriteLine(result);
        }
    }
}