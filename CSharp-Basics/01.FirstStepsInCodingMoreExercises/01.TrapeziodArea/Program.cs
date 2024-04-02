//input
double b1 = double.Parse(Console.ReadLine());   
double b2 = double.Parse(Console.ReadLine());
double h = double.Parse(Console.ReadLine());

//calculation
double trapeziodArea = ((b1 + b2) * h) / 2;
string formattedTrapeziodArea = trapeziodArea.ToString("0.00");

//output
Console.WriteLine(formattedTrapeziodArea);