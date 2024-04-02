int tabs = int.Parse(Console.ReadLine());  
double salary = double.Parse(Console.ReadLine());

for (int i = 0; i < tabs; i++)
{
    string webSait = Console.ReadLine();
    switch (webSait)
    {
        case "Facebook": salary -= 150; break;
        case "Instagram": salary -= 100; break;
        case "Reddit": salary -= 50; break;
        default:
            break;
    }
    if (salary <= 0)
    {
        Console.WriteLine("You have lost your salary.");
        break;
    }
}
if (salary > 0)
{
    int intSalary = (int)salary;
    Console.WriteLine(intSalary);
}