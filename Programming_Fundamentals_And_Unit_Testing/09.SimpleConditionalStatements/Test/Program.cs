namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfDay =int.Parse(Console.ReadLine());

            string result = numberOfDay switch
            {
                >= 1 and <= 5 => "Weekday!",
                > 5 and <= 7 => "WeekEnd!",
                _ => "Invalid day!"
            };
            Console.WriteLine(result);
        }
    }
}