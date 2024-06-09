namespace _07.ZigZagArrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int counter = int.Parse(Console.ReadLine());

            int[] numbers1 = new int[counter];
            int[] numbers2 = new int[counter];

            for (int i = 0; i < counter; i++)
            {
                int[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                if (i % 2 == 0)
                {
                    numbers1[i] = input[0];
                    numbers2[i] = input[1];
                }
                else
                {
                    numbers1[i] = input[1];
                    numbers2[i] = input[0];
                }
            }

            Console.WriteLine(string.Join(" ", numbers1));
            Console.WriteLine(string.Join(" ", numbers2));
        }
    }
}