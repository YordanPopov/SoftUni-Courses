namespace _05.DigitsLettersAndOthers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string digits = string.Empty;
            string letters = string.Empty;
            string characters = string.Empty;

            foreach (char c in input)
            {
                if (char.IsDigit(c))
                {
                    digits += c;
                }
                else if (char.IsLetter(c))
                {
                    letters += c;
                }
                else
                {
                    characters += c;
                }
            }

            Console.WriteLine(digits);
            Console.WriteLine(letters);
            Console.WriteLine(characters);
        }
    }
}