namespace _04.Building
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int floorsCount = int.Parse(Console.ReadLine());
            int estatesCount = int.Parse(Console.ReadLine());

            for (int i = floorsCount; i > 0; i--)
            {
                if (i == floorsCount)
                {
                    for (int j = 0; j < estatesCount; j++)
                    {
                        Console.Write($"L{i}{j} ");
                    }
                }else if (i % 2 != 0)
                {
                    for (int j = 0; j < estatesCount; j++)
                    {
                        Console.Write($"A{i}{j} ");
                    }
                }
                else
                {
                    for (int j = 0; j < estatesCount; j++)
                    {
                        Console.Write($"O{i}{j} ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}