double budget = double.Parse(Console.ReadLine());
bool isEmpty = false;

while (true)
{   
    string command = Console.ReadLine();
    double reward;
    if (command == "ACTION")
    {
        break;
    }
    if (command.Length <= 15)
    {
       reward = double.Parse(Console.ReadLine());
    }
    else
    {
        reward = budget * 0.2;
    }
    budget -= reward;
    if (budget <= 0)
    {
        isEmpty = true;
        break;
    } 
}
if (!isEmpty)
{
    Console.WriteLine($"We are left with {Math.Abs(budget):f2} leva.");
}
else
{
    Console.WriteLine($"We need {Math.Abs(budget):f2} leva for our actors.");
}