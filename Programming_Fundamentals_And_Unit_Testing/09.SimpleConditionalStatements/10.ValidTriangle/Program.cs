namespace _10.ValidTriangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Input
            int sideA = int.Parse(Console.ReadLine());
            int sideB = int.Parse(Console.ReadLine());
            int sideC = int.Parse(Console.ReadLine());

            //Calculations and Output
            bool isValid = (sideA < (sideB + sideC) && sideB < (sideA + sideC) && sideC < (sideB + sideA));
            string result = (isValid) ? "Valid Triangle" : "Invalid Triangle";
            Console.WriteLine(result);
        }
    }
}