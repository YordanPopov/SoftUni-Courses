namespace _02._2VowelsCount
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputFromConsole = Console.ReadLine();

            PrintNumberOfVowels(inputFromConsole);
        }

        static void PrintNumberOfVowels(string text)
        {
            int sum = 0;

            for (int i = 0; i < text.Length; i++)
            {
                char digit = text[i];
               if (digit == 'a' || digit == 'e' || digit == 'i' || digit == 'o' || digit == 'u' || 
                   digit == 'A' || digit == 'E' || digit == 'I' || digit == 'O' || digit == 'U')
                {
                    sum++;
                }
            }
            Console.WriteLine(sum);
        }
    }
}