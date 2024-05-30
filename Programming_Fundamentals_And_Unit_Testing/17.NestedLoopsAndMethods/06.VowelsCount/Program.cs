using System.Globalization;

namespace _06.VowelsCount
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            PrintCountOfVowels(text);
        }

        static void PrintCountOfVowels(string text)
        {
            text = text.ToLower();
            int countOfVowels = 0;

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == 'a' || text[i] == 'e' || text[i] == 'i' || text[i] == 'o' || text[i] == 'u')
                {
                    countOfVowels++;
                }
            }
            Console.WriteLine(countOfVowels);
        }
    }
}