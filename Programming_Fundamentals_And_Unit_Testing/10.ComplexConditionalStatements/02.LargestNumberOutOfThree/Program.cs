namespace _02.LargestNumberOutOfThree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Input
            int fisrtNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int thirdNumber = int.Parse(Console.ReadLine());

            // Calculations
            int largestNumber;
            if (fisrtNumber > secondNumber )
            {
                largestNumber = (fisrtNumber > thirdNumber) ? largestNumber = fisrtNumber : largestNumber = thirdNumber;
            }
            else
            {
                largestNumber = (secondNumber > thirdNumber) ? largestNumber = secondNumber : largestNumber = thirdNumber;
            }

            // Output
            Console.WriteLine(largestNumber);
        }
    }
}