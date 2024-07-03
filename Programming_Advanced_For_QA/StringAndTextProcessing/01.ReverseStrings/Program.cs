using System.Text;

namespace _01.ReverseStrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "end")
            {
                string reversedText = ReverseTextUsingStringBuilder(input);

                Console.WriteLine($"{input} = {reversedText}");
            }

        }

        static string ReverseTexUsingArray(string text)
        {
            char[] charArr = text.ToCharArray();
            Array.Reverse(charArr);
            string reversedText = new string(charArr);
            return reversedText;
        }

        static string ReverseTextUsingLINQ(string text)
        {
            string reversedText = new string(text.Reverse().ToArray());
            return reversedText;
        }

        static string ReverseTextUsingForLoop(string text)
        {
            string reversedText = string.Empty;

            for (int i = text.Length - 1; i >= 0; i--)
            {
                char currentLeeter = text[i];
                reversedText += currentLeeter;
            }

            return reversedText;
        }

        static string ReverseTextUsingStringBuilder(string text)
        {
            StringBuilder reversedText = new StringBuilder();

            for (int i = text.Length - 1; i >= 0; i--)
            {
                reversedText.Append(text[i]);
            }

            return reversedText.ToString();
        }

    }
}