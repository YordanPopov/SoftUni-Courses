//Input
double filmBudget = double.Parse(Console.ReadLine()); 
int numberOfStatistics = int.Parse(Console.ReadLine()); 
double priceOfClothingPerOneStatist = double.Parse(Console.ReadLine()); 

//Calculations
double decorating = filmBudget * 0.1;
double priceOfClothing = numberOfStatistics * priceOfClothingPerOneStatist;
if (numberOfStatistics > 150)
{
    priceOfClothing *= 0.9;
}

//Output
if (decorating + priceOfClothing > filmBudget)
{
    double neededMoney = (decorating + priceOfClothing) - filmBudget;
    Console.WriteLine("Not enough money!");
    Console.WriteLine($"Wingard needs {neededMoney:f2} leva more.");
}
else
{
    double leftMoney = filmBudget - (priceOfClothing + decorating);
    Console.WriteLine("Action!");
    Console.WriteLine($"Wingard starts filming with {leftMoney:f2} leva left.");
}




