namespace _07.WorkingHours
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int hour = int.Parse(Console.ReadLine());
            string weekDay = Console.ReadLine();

            string result = (hour >= 10 && hour <= 18) ?
                 result = weekDay switch
                 {
                     "Sunday" => "closed",
                     _ => "open"
                 } : "closed";
            Console.WriteLine(result);
        }
    }
}