using static System.Net.Mime.MediaTypeNames;

namespace _09._1.PalindromeIntegers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text;

            while ((text = Console.ReadLine()) != "END")
            {
                bool isPalindrom = IsPalindrom(text);
                string result = (isPalindrom) ? "true" : "false";
                Console.WriteLine(result);
            }
        }

        static bool IsPalindrom(string text)
        {
            string revertedText = "";

            for (int i = text.Length - 1; i >= 0; i--)
            {
                char digit = (char)text[i];
                revertedText += digit;
            }
            
            return (text == revertedText) ? true : false;
        }
    }
}



