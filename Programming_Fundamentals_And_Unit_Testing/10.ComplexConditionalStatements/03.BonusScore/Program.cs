namespace _03.BonusScore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Input
            int points = int.Parse(Console.ReadLine());

            // Calculations
            int bonusPoints = (points >= 0 && points <= 3) ? points += 5 : (points > 3 && points <= 6) ? points += 15 : points += 20;

            // Outputs
            Console.WriteLine(bonusPoints);
        }
    }
}