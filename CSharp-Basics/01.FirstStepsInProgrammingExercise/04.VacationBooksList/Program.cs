//input
int pagesOfBook = int.Parse(Console.ReadLine());  
int pagesReadsPerHour = int.Parse(Console.ReadLine());   
int daysToReadTheBook = int.Parse(Console.ReadLine());

//calculations

int hoursToReadTheBook = (pagesOfBook / pagesReadsPerHour) / daysToReadTheBook;

//output

Console.WriteLine(hoursToReadTheBook);