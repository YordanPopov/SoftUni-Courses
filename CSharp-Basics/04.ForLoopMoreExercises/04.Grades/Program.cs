int countOfStudents = int.Parse(Console.ReadLine());

int topStudent = 0;
int goodStudent = 0;
int mediumStudent = 0;
int failStudent = 0;
double sumOfRatings = 0;

for (int student = 0; student < countOfStudents; student++)
{
    double rateOfStudent = double.Parse(Console.ReadLine());
    sumOfRatings += rateOfStudent;
    if (rateOfStudent < 3.00)
    {
        failStudent++;
    }else if (rateOfStudent >= 3.00 && rateOfStudent <= 3.99)
    {
        mediumStudent++;
    }else if (rateOfStudent >= 4.00 && rateOfStudent < 5.00)
    {
        goodStudent++;
    }else if (rateOfStudent >= 5.00)
    {
        topStudent++;
    }

}

double avrRating = sumOfRatings / countOfStudents;
Console.WriteLine($"Top students: {(double)topStudent / countOfStudents * 100:f2}%");
Console.WriteLine($"Between 4.00 and 4.99: {(double)goodStudent / countOfStudents * 100:f2}%");
Console.WriteLine($"Between 3.00 and 3.99: {(double)mediumStudent / countOfStudents * 100:f2}%");
Console.WriteLine($"Fail: {(double)failStudent / countOfStudents * 100:f2}%");
Console.WriteLine($"Average: {avrRating:f2}");