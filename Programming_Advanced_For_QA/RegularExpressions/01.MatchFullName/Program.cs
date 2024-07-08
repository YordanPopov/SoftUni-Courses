using System.Text.RegularExpressions;

namespace _01.MatchFullName
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\b(?<firstName>[A-Z][a-z]+) (?<lastName>[A-Z][a-z]+)\b";
            string input = Console.ReadLine();

            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(input);

            Console.WriteLine(String.Join(" ", matches));
        }
    }
}