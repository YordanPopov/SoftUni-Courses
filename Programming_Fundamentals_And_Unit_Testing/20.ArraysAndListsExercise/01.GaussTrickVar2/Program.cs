namespace _01.GaussTrickVar2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int outputNumbersLength = numbers.Length % 2 == 0 ? numbers.Length / 2 : numbers.Length / 2 + 1;
            int[] outputNumbers = new int[outputNumbersLength];

            for (int i = 0; i < outputNumbersLength; i++)
            {
                if (i == outputNumbersLength - 1 && numbers.Length % 2 != 0)
                {
                    outputNumbers[i] = numbers[i];
                }
                else 
                { 
                    int elementA = numbers[i];
                    int elementB = numbers[numbers.Length - 1 - i];
                    outputNumbers[i] = elementA + elementB;
                }
            }

            Console.WriteLine(string.Join(" ", outputNumbers));
        }
    }
}