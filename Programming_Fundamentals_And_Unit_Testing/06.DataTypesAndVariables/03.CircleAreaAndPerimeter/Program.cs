namespace _03.CircleAreaAndPerimeter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double circleRadius = double.Parse(Console.ReadLine());
            double circleArea = circleRadius * circleRadius * Math.PI;
            double circlePerimeter = 2 * Math.PI * circleRadius;
            Console.WriteLine($"Area = {circleArea:f2}");
            Console.WriteLine($"Perimeter = {circlePerimeter:f2}");
        }
    }
}