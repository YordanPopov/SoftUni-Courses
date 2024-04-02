int period = int.Parse(Console.ReadLine());

int doctors = 7;
int treatedPatient = 0;
int untreatedPatient = 0;

for (int i = 1; i <= period; i++)
{
    int countOfPationt = int.Parse(Console.ReadLine());
    if (i % 3 == 0 && (untreatedPatient > treatedPatient))
    {
        doctors++;
    }
    if (countOfPationt <= doctors)
    {
        treatedPatient += countOfPationt;
    }
    else
    {
        untreatedPatient += countOfPationt - doctors;
        treatedPatient += doctors;
    }
}
Console.WriteLine($"Treated patients: {treatedPatient}.");
Console.WriteLine($"Untreated patients: {untreatedPatient}.");

