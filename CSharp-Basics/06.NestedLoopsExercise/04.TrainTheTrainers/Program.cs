int countOfJury = int.Parse(Console.ReadLine());
string presentationName = Console.ReadLine();

double sumOfGradeForPresentation = 0;
double sumOfAllGrade = 0;
int couterForGrades = 0;

while (presentationName != "Finish")
{
    for (int i = 0; i < countOfJury; i++)
    {
        double currentGrade = double.Parse(Console.ReadLine());
        couterForGrades++; ;
        sumOfGradeForPresentation += currentGrade;
        sumOfAllGrade += currentGrade;
    }
    Console.WriteLine($"{presentationName} - {sumOfGradeForPresentation / countOfJury:f2}.");
    sumOfGradeForPresentation = 0;
    presentationName = Console.ReadLine();
}

Console.WriteLine($"Student's final assessment is {sumOfAllGrade / couterForGrades:f2}.");