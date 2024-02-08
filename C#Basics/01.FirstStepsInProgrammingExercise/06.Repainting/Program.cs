//input
int amountOfNylon = int.Parse(Console.ReadLine()) + 2;
double amountOfPaint = double.Parse(Console.ReadLine()) * 1.1;
int amountOfThinner = int.Parse(Console.ReadLine());
int hoursToWork = int.Parse(Console.ReadLine());

//calculations
double sumOfProducts = (amountOfNylon * 1.50) + (amountOfPaint * 14.50) + (amountOfThinner * 5.00) + 0.40;
double sumOfWorks = (sumOfProducts * 0.3) * hoursToWork;
double totalSum = sumOfProducts + sumOfWorks;

//output
Console.WriteLine(totalSum);
