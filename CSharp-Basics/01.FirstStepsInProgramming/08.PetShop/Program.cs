//input
int countDogFood = int.Parse(Console.ReadLine());   
int countCatFood = int.Parse(Console.ReadLine());

//calculation 
double Price = (countDogFood * 2.5) + (countCatFood * 4);

//output
Console.WriteLine($"{Price} lv.");