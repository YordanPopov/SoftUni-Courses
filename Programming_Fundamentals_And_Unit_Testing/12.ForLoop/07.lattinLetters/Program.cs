namespace _07.lattinLetters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char startingLetter = char.Parse(Console.ReadLine()),
                 finalLetter = char.Parse(Console.ReadLine());
            for (char i = startingLetter; i <= finalLetter; i++)
            {
                Console.Write($"{i} ");
            }
        }
    }
}