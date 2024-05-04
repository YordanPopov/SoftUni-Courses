namespace _02.FirstNnumberSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine()),
                sum = 1;
            Console.Write(sum);
            for (int i = 2; i <= number; i++)
            {
                sum += i;
                Console.Write($"+{i}");
            }
            Console.Write($"={sum}");
        }
    }
}