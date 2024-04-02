string nameOfCompany = Console.ReadLine();
int numberOfTicketsForAdults = int.Parse(Console.ReadLine());
int numberOfTicketsForKids = int.Parse(Console.ReadLine());
double priceForAdultTicket = double.Parse(Console.ReadLine());  
double priceForBill = double.Parse(Console.ReadLine());

double totalSum = 0;
double priceForKidsTicket = priceForAdultTicket - (priceForAdultTicket * 0.7);
totalSum = ((priceForAdultTicket + priceForBill) * numberOfTicketsForAdults) + ((priceForKidsTicket + priceForBill) * numberOfTicketsForKids);
totalSum *= 0.2;

Console.WriteLine($"The profit of your agency from {nameOfCompany} tickets is {totalSum:f2} lv.");