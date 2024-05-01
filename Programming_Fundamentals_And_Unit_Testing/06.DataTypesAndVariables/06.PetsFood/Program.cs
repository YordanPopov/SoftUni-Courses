namespace _06.PetsFood
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countPackagesDogFood = int.Parse(Console.ReadLine());
            int countPackagesCatFood = int.Parse(Console.ReadLine());
            double expenses = (2.50 * countPackagesDogFood) + (4.00 * countPackagesCatFood);
            Console.WriteLine($"{expenses:f2} lv.");
        }
    }
}