namespace _01.SquareRoot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int number = int.Parse(Console.ReadLine());

                Console.WriteLine(GetSquare(number));
            }
            catch(ArgumentException) 
            {
                Console.WriteLine("Invalid number.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid parse.");
            }
            finally
            {
                Console.WriteLine("Goodbye.");
            }
        }

        static double GetSquare(int number)
        {
            if(number < 0)
            {
                throw new ArgumentException();
            }

            return Math.Sqrt(number);
        }
    }
}