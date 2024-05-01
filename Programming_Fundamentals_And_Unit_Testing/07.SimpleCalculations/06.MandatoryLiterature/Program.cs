namespace _06.MandatoryLiterature
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Inputs
            int numberOfPages = int.Parse(Console.ReadLine());
            int pagesPerHour = int.Parse(Console.ReadLine());
            int numberOfDays = int.Parse(Console.ReadLine());

            //Calculations
            int numberOfHoursToReadTheBook = (numberOfPages / pagesPerHour) / numberOfDays;

            // Output
            Console.WriteLine(numberOfHoursToReadTheBook);
        }
    }
}