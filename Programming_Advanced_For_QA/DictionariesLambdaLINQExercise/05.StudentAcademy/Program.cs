using System.Threading.Channels;

namespace _05.StudentAcademy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> students = new();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string student = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (!students.ContainsKey(student))
                {
                    students.Add(student, new List<double> { grade });
                }
                else
                {
                    students[student].Add(grade);
                }
            }

           var excellentStudents = students.Where(student => student.Value.Average() >= 4.50);

            foreach (var student in excellentStudents)
            {
                Console.WriteLine($"{student.Key} -> {student.Value.Average():F2}");
            }

        }
    }
}