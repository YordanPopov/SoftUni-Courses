namespace _03.RectangleArea
{
    internal class Program
    {
        static void Main(string[] args)
        {
           int length = int.Parse(Console.ReadLine());
           int width = int.Parse(Console.ReadLine());
           int rectangleArea = length * width;
            Console.WriteLine(rectangleArea);
        }
    }
}