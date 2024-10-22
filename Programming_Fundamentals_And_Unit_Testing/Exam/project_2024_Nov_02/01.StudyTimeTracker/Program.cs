namespace _01.StudyTimeTracker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countFoodItems = int.Parse(Console.ReadLine());

            if (countFoodItems <= 0)
            {
                Console.WriteLine(0);
                return;
            }

            int studyTime = 0;

            for (int i = 1; i <= countFoodItems; i++)
            {
                int duration = int.Parse(Console.ReadLine());
                studyTime += duration;
                Console.WriteLine(studyTime);
            }
        }
    }
}