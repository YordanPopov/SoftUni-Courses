namespace _02.Grades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double grade = double.Parse(Console.ReadLine());
            PrintResult(grade);
        }
        static void PrintResult(double grade)
        {
            string result = (grade < 3.00) ? "Fail" :
                            (grade < 3.50) ? "Average" :
                            (grade < 4.50) ? "Good" :
                            (grade < 5.50) ? "Very good" :
                            (grade < 6.00) ? "Excellent" : "";
            Console.WriteLine(result);
        }
    }
}