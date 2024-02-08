//input
int chickenMenu = int.Parse(Console.ReadLine());
int fishMenu = int.Parse(Console.ReadLine()); ;
int vegetarianMenu = int.Parse(Console.ReadLine());

//calculation
double menuSum = (chickenMenu * 10.35) + (fishMenu * 12.40) + (vegetarianMenu * 8.15);
double dessert = menuSum * 0.2;
double totalSum = menuSum + dessert + 2.50;

//output
Console.WriteLine(totalSum);