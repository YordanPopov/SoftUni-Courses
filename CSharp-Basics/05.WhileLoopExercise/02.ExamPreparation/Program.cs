int countOfBadGrades  = int.Parse(Console.ReadLine());

int badGrades = 0;
int solvedExam = 0;
double gradeSum = 0;
string lastExam = "";
bool isFaled = false;

while (badGrades < countOfBadGrades)
{
    string examName = Console.ReadLine();
    if (examName == "Enough")
    {
        isFaled = true;
        break;
    }
    double currentGrade = double.Parse(Console.ReadLine());
    if (currentGrade <= 4)
    {
        badGrades++;
    }
    gradeSum += currentGrade;
    solvedExam++;
    lastExam = examName;

}
if (isFaled)
{
    Console.WriteLine($"Average score: {gradeSum / solvedExam:f2}");
    Console.WriteLine($"Number of problems: {solvedExam}");
    Console.WriteLine($"Last problem: {lastExam}");
}
else
{
    Console.WriteLine($"You need a break, {badGrades} poor grades.");
}