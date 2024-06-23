namespace _01.CountLetters
{
    internal class Program
    {
        static void Main(string[] args)
        {
           string inputFromConsole = Console.ReadLine();

            int upperCaseLetter = 0;
            int lowerCaseLetter = 0;
            int whiteSpaces = 0;

            foreach (char letter in inputFromConsole)
            {

                if (char.IsUpper(letter))
                {
                    upperCaseLetter++;
                }
                else if (char.IsLower(letter))
                {
                    lowerCaseLetter++;
                }
                else if (char.IsWhiteSpace(letter))
                {
                    whiteSpaces++;
                }
            }
            Console.WriteLine(upperCaseLetter);
            Console.WriteLine(lowerCaseLetter);
            Console.WriteLine(whiteSpaces);
        }
    }
}