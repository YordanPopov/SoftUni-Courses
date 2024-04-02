string actor = Console.ReadLine();
double pointsOfAcademy = double.Parse(Console.ReadLine());  
int numberOfJury = int.Parse(Console.ReadLine());

double pointsOfJury = 0.0;
bool isNominated = false;
double nominatePoints = 1250.5;

for (int jury = 0; jury < numberOfJury; jury++)
{
    string nameOfJury = Console.ReadLine();
    double points = double.Parse(Console.ReadLine());
    pointsOfJury += (nameOfJury.Length * points) / 2;

    if (pointsOfAcademy + pointsOfJury > nominatePoints) 
    {
        isNominated = true;
        break;
    }
}

if (isNominated)
{
    Console.WriteLine($"Congratulations, {actor} got a nominee for leading role with {pointsOfJury + pointsOfAcademy:f1}!");
}
else
{
    Console.WriteLine($"Sorry, {actor} you need {nominatePoints - (pointsOfAcademy + pointsOfJury):f1} more!");
}