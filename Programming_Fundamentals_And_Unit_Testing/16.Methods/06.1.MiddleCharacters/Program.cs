namespace _06._1.MiddleCharacters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
           
            FindAndPrintMiddleCharacter(text);
        }

        static void FindAndPrintMiddleCharacter(string text)
        {
            int middleText = text.Length / 2;

            if (text.Length % 2 == 0)
            {
                Console.WriteLine($"{text[middleText - 1]}{text[middleText]}");
            }
            else
            {
                Console.WriteLine($"{text[middleText]}");
            }
        }
    }
}