//input
double depositSum = double.Parse(Console.ReadLine());  
int termOfDepositInMonths = int.Parse(Console.ReadLine());  
double annualInterestRate = double.Parse(Console.ReadLine())/100;

//calculations
double realSum = depositSum + termOfDepositInMonths * ((depositSum * annualInterestRate)/12);

//output
Console.WriteLine(realSum);