namespace _05.EqualsArrays
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

            bool isIdentical = true;

            for (int i = 0; i < firstArray.Length; i++)
            {
                if (firstArray[i] != secondArray[i])
                {
                    isIdentical = false;
                    break;
                }
            }

            if (isIdentical)
            {
                Console.WriteLine("Arrays are identical.");
            }
            else
            {
                Console.WriteLine("Arrays are not identical.");
            }
        }
    }
}