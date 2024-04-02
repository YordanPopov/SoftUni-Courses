//Input
double number = double.Parse(Console.ReadLine());
//Calculations and Output
bool isValid = number >= 100 && number <= 200 || number == 0;

if (!isValid)
{
    Console.WriteLine("invalid");
}