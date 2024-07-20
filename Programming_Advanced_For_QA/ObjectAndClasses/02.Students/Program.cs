using System.Security.Cryptography.X509Certificates;

namespace _02.Students
{
    internal class Program
    {
        class Student
        {
            public string FirstName { get; set; }

            public string LastName { get; set; }

            public int Age { get; set; }

            public string HomeTown { get; set; }

            public Student(string firstName, string lastName, int age, string homeTown) 
            {
                FirstName = firstName;
                LastName = lastName;
                Age = age;
                HomeTown = homeTown;
            }
        }

        static void Main(string[] args)
        {
            List<Student> students = new();

            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            while (input[0] != "end")
            {
                string firstName = input[0];
                string lastName = input[1];
                int age = int.Parse(input[2]);
                string homeTown = input[3];

                Student curentStudent = new Student(firstName, lastName, age, homeTown);

                students.Add(curentStudent);

                input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            string townCity = Console.ReadLine();

            List<Student> filteredStudents = students.Where(s => s.HomeTown == townCity).ToList();

            foreach (Student student in filteredStudents)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
            }
        }
    }
}