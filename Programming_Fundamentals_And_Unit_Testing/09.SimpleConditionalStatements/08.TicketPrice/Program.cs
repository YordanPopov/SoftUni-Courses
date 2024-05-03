namespace _08.TicketPrice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string ticketType = Console.ReadLine();

            string ticketPrice = ticketType switch
            {
                "student" => "$1.00",
                "regular" => "$1.60",
                _ => "Invalid ticket type!",
            };
            Console.WriteLine(ticketPrice);
        }
    }
}