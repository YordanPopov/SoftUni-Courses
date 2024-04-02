//input
double pricePerVacation = double.Parse(Console.ReadLine());
double numberOfPuzzles = double.Parse(Console.ReadLine());
double numberOfDolls = double.Parse(Console.ReadLine());
double numberOfBears = double.Parse(Console.ReadLine());
double numberOfMinions = double.Parse(Console.ReadLine());
double numberOfTrucks = double.Parse(Console.ReadLine());

double puzzlePrice = 2.60;
double dollPrice = 3.00;
double teddyBearPrice = 4.10;
double minionPrice = 8.20;
double truckPrice = 2.00;

//calculations
double totalPrice = (numberOfPuzzles * puzzlePrice) + (numberOfDolls * dollPrice) + (numberOfBears *teddyBearPrice) +
    (numberOfMinions * minionPrice) + (numberOfTrucks * truckPrice);

if ((numberOfPuzzles + numberOfDolls + numberOfBears + numberOfMinions + numberOfTrucks) >= 50)
{
    totalPrice *= 0.75;
}

totalPrice *= 0.9; //Отстъпка за наема.
//output
if (totalPrice >= pricePerVacation)
{
    double leftMoney = totalPrice - pricePerVacation;
    Console.WriteLine($"Yes! {leftMoney:F2} lv left.");
}
else
{
    double neededMoney = pricePerVacation - totalPrice;
    Console.WriteLine($"Not enough money! {neededMoney:F2} lv needed.");
}