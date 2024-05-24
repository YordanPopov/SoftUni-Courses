namespace _04.CalculateRectangleArea
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rectangleWidth = int.Parse(Console.ReadLine());
            int rectangleLength = int.Parse(Console.ReadLine());
            Console.WriteLine(RectangleArea(rectangleWidth, rectangleLength));
        }

        static int RectangleArea(int width, int length)
        {
            int area = width * length;
            return area;
        }
    }
}