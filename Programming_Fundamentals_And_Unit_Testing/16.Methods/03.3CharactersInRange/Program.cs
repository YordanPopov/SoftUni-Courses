namespace _03._3CharactersInRange
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char firstChar = char.Parse(Console.ReadLine());
            char secondChar = char.Parse(Console.ReadLine());

            PrintCharacters(firstChar, secondChar);
        }

        static void PrintCharacters(char firstSymbol, char secondSymbol)
        {
            if (firstSymbol < secondSymbol)
            {
                for (int i = firstSymbol + 1; i < secondSymbol; i++)
                {
                    Console.Write($"{(char)i} ");
                }
            }
            else
            {
                for (int i = secondSymbol + 1; i < firstSymbol; i++)
                {
                    Console.Write($"{(char)i} ");
                }
            }
        }
    }
}