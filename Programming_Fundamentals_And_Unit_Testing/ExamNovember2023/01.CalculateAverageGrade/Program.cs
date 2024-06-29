namespace _01.CalculateAverageGrade
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int studentsCount = int.Parse(Console.ReadLine());

            double gradesSum = 0d;

            for (int i = 0; i < studentsCount; i++)
            {
                
                double grade = double.Parse(Console.ReadLine());
                gradesSum += grade;

            }

            double averageGrade = gradesSum / studentsCount;
            Console.WriteLine($"{averageGrade:F2}");
        }
    }
}