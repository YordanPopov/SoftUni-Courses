namespace _06.ExamCountdown
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int currentDay = int.Parse(Console.ReadLine());
            for (int i = currentDay; i >= 1; i--)
            {
                Console.WriteLine($"{i} days before the exam");
            }
            Console.WriteLine("The exam has come");
        }
    }
}