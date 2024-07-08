using System.Text.RegularExpressions;

namespace _03.MatchDates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string patterns = @"\b(?<day>\d{2})(?<sep>[\-\.\/])(?<month>[A-Z][a-z]+)\k<sep>(?<year>\d{4})\b";
            string input = Console.ReadLine();


            Regex regex = new Regex(patterns);
            MatchCollection matches = regex.Matches(input);

            foreach (Match match in matches)
            {
                Console.WriteLine($"Day: {match.Groups["day"]}, Month: {match.Groups["month"]}, Year: {match.Groups["year"]}");
            }
        }
    }
}