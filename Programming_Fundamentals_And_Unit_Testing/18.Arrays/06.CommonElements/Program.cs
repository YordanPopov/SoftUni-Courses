namespace _06.CommonElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] firstArray = Console.ReadLine()
                                .Split()
                                .Select(int.Parse)
                                .ToArray();
            int[] secondArray = Console.ReadLine()
                                .Split()
                                .Select(int.Parse)
                                .ToArray();

            for (int i = 0; i < firstArray.Length; i++)
            {
                for (int j = 0; j < secondArray.Length; j++)
                {
                    if (firstArray[i] == secondArray[j])
                    {
                        Console.Write($"{firstArray[i]} ");
                    }
                }
            }
        }
    }
}