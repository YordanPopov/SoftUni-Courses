namespace _07.ProjectCreation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string nameOfArchitect = Console.ReadLine();
            int countOfProjects = int.Parse(Console.ReadLine());
            int neededHoursForCreationProject = countOfProjects * 3;
            Console.WriteLine($"The architect {nameOfArchitect} will need {neededHoursForCreationProject} hours to complete {countOfProjects} project/s.");
        }
    }
}