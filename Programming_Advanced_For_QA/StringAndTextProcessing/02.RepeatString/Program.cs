namespace _02.RepeatString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Console.WriteLine(RepeatText(input));
        }

        static string RepeatText(string[] text)
        {
            string repeatedText = string.Empty;

            foreach (string word in text)
            {
                
                for (int i = 0; i < word.Length; i++)
                {
                    repeatedText += word;
                }
            }

            return repeatedText;
        }
    }
}