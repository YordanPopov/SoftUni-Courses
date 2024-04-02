int numberOfGroups = int.Parse(Console.ReadLine());

int totalPeople = 0;
int peopleClimbMusala = 0;
int peopleClimbMonblan = 0;
int peopleClimbKilimandjaro = 0;
int peopleClimbK2 = 0;
int peopleClimbEverest = 0;
for (int group = 0; group < numberOfGroups; group++)
{
    int peopleInOneGroup = int.Parse(Console.ReadLine());
    totalPeople += peopleInOneGroup;
    if (peopleInOneGroup <= 5)
    {
        peopleClimbMusala += peopleInOneGroup;
    }else if (peopleInOneGroup >= 6 && peopleInOneGroup <= 12)
    {
        peopleClimbMonblan += peopleInOneGroup;
    }else if (peopleInOneGroup >= 13 && peopleInOneGroup <= 25)
    {
        peopleClimbKilimandjaro += peopleInOneGroup;
    }else if (peopleInOneGroup >= 26 && peopleInOneGroup <= 40)
    {
        peopleClimbK2 += peopleInOneGroup;
    }else if (peopleInOneGroup > 40)
    {
        peopleClimbEverest += peopleInOneGroup;
    }
}

double percentageMusala = ((double)peopleClimbMusala / totalPeople) * 100;
double percentageMonblan = ((double)peopleClimbMonblan / totalPeople) * 100;
double percentageKilimandjaro = ((double)peopleClimbKilimandjaro / totalPeople) * 100;
double percentageK2 = ((double)peopleClimbK2 / totalPeople) * 100;
double percentageEverest = ((double)peopleClimbEverest / totalPeople) * 100;

Console.WriteLine($"{percentageMusala:f2}%");
Console.WriteLine($"{percentageMonblan:f2}%");
Console.WriteLine($"{percentageKilimandjaro:f2}%");
Console.WriteLine($"{percentageK2:f2}%");
Console.WriteLine($"{percentageEverest:f2}%");
