
int capacity = int.Parse(Console.ReadLine());

int allPeople = 0;
double totalSum = 0;
bool isFull = false;

string command = Console.ReadLine();

while (command != "Movie time!")
 {
    int countOfPeople = int.Parse(command);
    allPeople += countOfPeople;
      if (allPeople > capacity)
      {
        isFull = true;
        break;
      }
      if (countOfPeople % 3 == 0)
      {
        totalSum += (countOfPeople * 5) - 5;
      }
      else
      {
        totalSum += (countOfPeople * 5);
      }
    command = Console.ReadLine();
}
 if (isFull)
{
    Console.WriteLine("The cinema is full.");
    Console.WriteLine("Cinema income - {0} lv.", totalSum);
}
else
{
    int leftSeats = capacity - allPeople;
    Console.WriteLine("There are {0} seats left in the cinema.", leftSeats);
    Console.WriteLine("Cinema income - {0} lv.", totalSum);
}
