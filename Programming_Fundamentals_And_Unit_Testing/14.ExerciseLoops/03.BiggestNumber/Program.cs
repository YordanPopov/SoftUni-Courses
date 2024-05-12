namespace _03.BiggestNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int amountOfNumbers = int.Parse(Console.ReadLine());
            int maxNumber = int.MinValue;
            for (int i = 0; i < amountOfNumbers; i++)
            {
                int number = int.Parse(Console.ReadLine());
                maxNumber = (number > maxNumber) ? number : maxNumber;
            }
            Console.WriteLine(maxNumber);
        }
    }
}