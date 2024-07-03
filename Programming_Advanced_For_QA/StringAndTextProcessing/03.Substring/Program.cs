namespace _03.Substring
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string keyword = Console.ReadLine();
            string text = Console.ReadLine();

            Console.WriteLine(RemoveKeywordFromText(keyword, text));

        }

        static string RemoveKeywordFromText(string keyword, string text)
        {
          
            while (text.Contains(keyword))
            {
                text = text.Remove(text.IndexOf(keyword), keyword.Length);
            }

            return text;
        }
    }
}