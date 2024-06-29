namespace _02.Rotations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int rotations = int.Parse(Console.ReadLine());

            for (int i = 0; i < rotations; i++)
            {
                numbers.Insert(0, numbers[numbers.Count-1]);
                numbers.RemoveAt(numbers.Count-1);

            }

            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}