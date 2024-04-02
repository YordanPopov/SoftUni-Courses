//Input
int poolVolume = int.Parse(Console.ReadLine()); //обем на басейна в литри
int debit1pipe = int.Parse(Console.ReadLine()); // дебит на първата тръба за час
int debit2pipe = int.Parse(Console.ReadLine()); //дебит на втората тръба за час
double HoursAbsent = double.Parse(Console.ReadLine()); // часове, които работника отсъства

//Calculation
double totalDebit = (debit1pipe + debit2pipe) * HoursAbsent;

//Output
if (poolVolume >= totalDebit)
{
    double poolFilledPercent = (totalDebit / poolVolume) * 100;
    double pipe1Percent = (debit1pipe * HoursAbsent / totalDebit) * 100;
    double pipe2Percent = (debit2pipe * HoursAbsent / totalDebit) * 100;
    Console.WriteLine($"The pool is {poolFilledPercent:f2}% full. Pipe 1: {pipe1Percent:f2}%. Pipe 2: {pipe2Percent:f2}%.");
} 
else
{
    Console.WriteLine($"For {HoursAbsent:f2} hours the pool overflows with {totalDebit - poolVolume:f2} liters.");
}

