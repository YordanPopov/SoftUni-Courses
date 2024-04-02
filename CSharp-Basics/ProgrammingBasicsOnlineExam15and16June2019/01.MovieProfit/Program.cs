string movieName = Console.ReadLine();
int days = int.Parse(Console.ReadLine());
int numberOfTickets = int.Parse(Console.ReadLine());
double ticketPrice = double.Parse(Console.ReadLine());
double percentageEarning = double.Parse(Console.ReadLine()) / 100;

double ticketsPriceForDay = numberOfTickets * ticketPrice;
double allTicketsPrice = days * ticketsPriceForDay;
double totalSum = allTicketsPrice - (allTicketsPrice * percentageEarning);

Console.WriteLine($"The profit from the movie {movieName} is {totalSum:f2} lv.");