namespace _01.Students
{
    internal class Program
    {
        class Student
        {
            public string FirstName { get; set; }

            public string LastName { get; set; }

            public double Grade { get; set; }

            public Student(string firstName, string lasName, double grade)
            {
                this.FirstName = firstName;
                this.LastName = lasName;
                this.Grade = grade;
            }
        }
        static void Main(string[] args)
        {
            List<Student> students = new();
            
            int countStudents = int.Parse(Console.ReadLine());

            for (int student = 1; student <= countStudents; student++)
            {
                string[] input = Console.ReadLine().Split();
                string firstName = input[0];
                string lastName = input[1];
                double grade = double.Parse(input[2]);

                Student currentStudent = new Student(firstName, lastName, grade);
                students.Add(currentStudent);
            }

            foreach (Student student in students.OrderByDescending(s => s.Grade))
            {
                Console.WriteLine($"{student.FirstName} {student.LastName}: {student.Grade:F2}");
            }
        }
    }
}