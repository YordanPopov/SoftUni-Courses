namespace _07.SpecialBonus
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int stopNumber = int.Parse(Console.ReadLine()),
                number = int.Parse(Console.ReadLine()),
                lastNumber = 0;

            while (number != stopNumber)
            {
                lastNumber = number;
                number = int.Parse(Console.ReadLine());
            }
            double bonus = lastNumber + (lastNumber * 0.2);
            Console.WriteLine(bonus);
        }
    }
}