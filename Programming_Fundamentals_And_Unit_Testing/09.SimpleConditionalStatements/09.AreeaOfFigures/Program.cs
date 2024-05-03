namespace _09.AreeaOfFigures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string figureType = Console.ReadLine();
            double figureArea = 0.0;

            if (figureType == "square")
            {
                double side = double.Parse(Console.ReadLine());
                figureArea = side * side;
            } else if(figureType == "rectangle")
            {
                double width = double.Parse(Console.ReadLine());
                double length = double.Parse(Console.ReadLine());
                figureArea = width * length;
            }else if(figureType == "circle")
            {
                double radius = double.Parse(Console.ReadLine());
                figureArea = Math.PI * radius * radius;
            }
            Console.WriteLine($"{figureArea:f2}");
        }
    }
}