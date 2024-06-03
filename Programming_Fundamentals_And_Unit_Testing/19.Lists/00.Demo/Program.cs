namespace _00.Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
           List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            for (int i = 0; i < numbers.Count; i++)
            {
                Console.WriteLine($"{numbers[i]}");
            }
        }
    }
}