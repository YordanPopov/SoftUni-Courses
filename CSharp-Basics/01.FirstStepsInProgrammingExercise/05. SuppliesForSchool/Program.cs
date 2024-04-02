//input
int numbersOfPacketsOfPens = int.Parse(Console.ReadLine()); // брой пакети химикали
int numbersOfPacketsOfTags = int.Parse(Console.ReadLine()); // брой пакети маркери
int litersForCleaning = int.Parse(Console.ReadLine()); // литри препарат за почистване на дъска
double discountPercent = double.Parse(Console.ReadLine())/100; //процент намаление

//calculation
double finalSum = (numbersOfPacketsOfPens * 5.80) + (numbersOfPacketsOfTags * 7.20) + (litersForCleaning * 1.20);
double sumWithDiscount = finalSum - (finalSum * discountPercent);

//output
Console.WriteLine(sumWithDiscount);