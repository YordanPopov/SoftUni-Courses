namespace _01.UsdToEur
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double dollars = double.Parse(Console.ReadLine());
            double euro = dollars * 0.88;
            Console.WriteLine($"{euro:f2}");
        }
    }
}