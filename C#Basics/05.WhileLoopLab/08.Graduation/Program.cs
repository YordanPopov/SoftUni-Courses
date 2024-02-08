using System;

public class Program
{
    public static void Main()
    {
        string nameOfStudent = Console.ReadLine();

        int badGrade = 0;
        double totalSumOfRate = 0;
        int gradeLevel = 1;

        while (gradeLevel <= 12)
        {
           
            double grade = double.Parse(Console.ReadLine());
            if (grade < 4)
            {
                badGrade++;
                if (badGrade < 2)
                {
                    continue;
                }
                else
                {
                    Console.WriteLine($"{nameOfStudent} has been excluded at {gradeLevel} grade");
                    break;
                }

            }
            totalSumOfRate += grade;
            gradeLevel++;
        }
        double avrRate = totalSumOfRate / 12;
        if (gradeLevel >= 12)
        {
            Console.WriteLine($"{nameOfStudent} graduated. Average grade: {avrRate:f2}");
        }
    }
}