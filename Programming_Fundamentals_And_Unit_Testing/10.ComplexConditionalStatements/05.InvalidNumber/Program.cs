namespace _05.InvalidNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            bool isValid = (number >= 100 && number <= 200) || (number == 0);
            string result = (!isValid) ? "invalid" : "";
            Console.WriteLine(result);
        }
    }
}