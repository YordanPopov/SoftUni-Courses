string nameOfActor = Console.ReadLine();
double countOfJury = double.Parse(Console.ReadLine());
int counter = int.Parse(Console.ReadLine());

double totalPoints = countOfJury;

for (int i = 0; i < counter; i++)
{
    string nameOfJury = Console.ReadLine();
    double points = double.Parse(Console.ReadLine());
    double juryPoints = nameOfJury.Length * points / 2.0;
    totalPoints += juryPoints;
    if (totalPoints > 1250.5)
    {
        Console.WriteLine($"Congratulations, {nameOfActor} got a nominee for leading role with {totalPoints:f1}!");
        return;
    }
}
 double neededPoints = 1250.5 - totalPoints;
 Console.WriteLine($"Sorry, {nameOfActor} you need {neededPoints:f1} more!");
