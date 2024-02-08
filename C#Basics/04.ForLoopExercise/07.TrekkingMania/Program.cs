int countOfGroups = int.Parse(Console.ReadLine());

double totalPeople = 0.0;
int countPeopleMusala = 0;
int countPeopleMonblan = 0;
int countPeopleKilimanjaro = 0;
int countPeopleK2 = 0;
int countPeopleEverest = 0;

for (int i = 1; i <= countOfGroups; i++)
{   
    
    int peopleInOneGroup = int.Parse(Console.ReadLine());
    totalPeople += peopleInOneGroup;
    if (peopleInOneGroup <= 5)
    {
        countPeopleMusala += peopleInOneGroup;
    }else if (peopleInOneGroup >= 6 && peopleInOneGroup <= 12)
    {
        countPeopleMonblan += peopleInOneGroup;
    }else if (peopleInOneGroup >= 13 && peopleInOneGroup <= 25)
    {
        countPeopleKilimanjaro += peopleInOneGroup;
    }else if (peopleInOneGroup >= 26 && peopleInOneGroup <= 40)
    {
        countPeopleK2 += peopleInOneGroup;
    }else if (peopleInOneGroup >= 41)
    {
        countPeopleEverest += peopleInOneGroup;
    }
}

double percentPeopleMusala = (countPeopleMusala / totalPeople) * 100.0;
double percentPeopleMonblan = (countPeopleMonblan / totalPeople) * 100.0;
double percentPeopleKilimanjaro = (countPeopleKilimanjaro / totalPeople) * 100.0;
double percentPeopleK2 = (countPeopleK2 / totalPeople) * 100.0;
double percentPeopleEverest = (countPeopleEverest / totalPeople) * 100.0;

Console.WriteLine($"{percentPeopleMusala:f2}%");
Console.WriteLine($"{percentPeopleMonblan:f2}%");
Console.WriteLine($"{percentPeopleKilimanjaro:f2}%");
Console.WriteLine($"{percentPeopleK2:f2}%");
Console.WriteLine($"{percentPeopleEverest:f2}%");
