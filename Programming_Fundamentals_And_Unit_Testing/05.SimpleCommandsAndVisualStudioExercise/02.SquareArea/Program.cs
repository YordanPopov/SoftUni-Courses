namespace _02.SquareArea
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sideOfSquare = int.Parse(Console.ReadLine());
            int area = sideOfSquare * sideOfSquare;
            Console.WriteLine(area);
        }
    }
}