string movieName = Console.ReadLine();

int studentsTickets = 0;
int standardTickets = 0;
int kidTickets = 0;
int allTickets = 0;
while (movieName != "Finish")
{
    int freeSeats = int.Parse(Console.ReadLine());
    int ticketsForMovie = 0;
    for(int i = 0; i < freeSeats; i++)
    {
        string tickets = Console.ReadLine();
        if (tickets == "End")
        {
            break;
        }
        switch (tickets)
        {
            case "student": studentsTickets++; break;
            case "standard": standardTickets++; break;
            case "kid": kidTickets++; break;
                default: break;
        }
        ticketsForMovie++;
        allTickets++;
    }   
        Console.WriteLine($"{movieName} - {((double)ticketsForMovie / freeSeats) * 100:f2}% full.");
        movieName = Console.ReadLine();
}
Console.WriteLine($"Total tickets: {allTickets}");
Console.WriteLine($"{(double)studentsTickets / allTickets * 100:f2}% student tickets.");
Console.WriteLine($"{(double)standardTickets / allTickets * 100:f2}% standard tickets.");
Console.WriteLine($"{(double)kidTickets / allTickets * 100:f2}% kids tickets.");