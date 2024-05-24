namespace _05.RepeatString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            int counter = int.Parse(Console.ReadLine());
            Console.WriteLine(GetRepeatedText(text, counter));
        }

        static string GetRepeatedText(string text, int counter)
        {
            string repeatedText = "";
            for (int i = 0; i < counter; i++)
            {
                repeatedText += text;
            }
            return repeatedText;
        }
    }
}