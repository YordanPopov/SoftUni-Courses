//input
string name = Console.ReadLine();   
int countProjects = int.Parse(Console.ReadLine());  

//calculation

int totalHours = 3 * countProjects;

//output

Console.WriteLine($"The architect {name} will need {totalHours} hours to complete {countProjects} project/s.");