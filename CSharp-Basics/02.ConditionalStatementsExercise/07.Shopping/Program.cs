//Input
double budget = double.Parse(Console.ReadLine()); 
int countOfVideoCards = int.Parse(Console.ReadLine());
int countOfCpu = int.Parse(Console.ReadLine());
int countOfMemory = int.Parse(Console.ReadLine());

//Calculation
double sumOfVideoCards = countOfVideoCards * 250;
double sumOfCpu = (sumOfVideoCards * 0.35) * countOfCpu;
double sumOfMemory = (sumOfVideoCards * 0.1) * countOfMemory;
double totalSum = sumOfVideoCards + sumOfCpu + sumOfMemory;

if (countOfVideoCards > countOfCpu)
{
    totalSum *= 0.85;
}

//Output 
if (budget >= totalSum)
{
    Console.WriteLine($"You have {budget - totalSum:f2} leva left!");
}
else
{
    Console.WriteLine($"Not enough money! You need {totalSum - budget:f2} leva more!");
}