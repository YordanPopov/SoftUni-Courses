namespace _01.DailyExerciseTracker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int daysCount = int.Parse(Console.ReadLine());
            int cumulativeTime = 0;

            if (daysCount <= 0 )
            {
                Console.WriteLine(0);
                return;
            }

            for (int day = 1; day <= daysCount; day++)
            {
                int exerciseTime = int.Parse(Console.ReadLine());
                cumulativeTime += exerciseTime;
                Console.WriteLine(cumulativeTime);
            }
        }
    }
}