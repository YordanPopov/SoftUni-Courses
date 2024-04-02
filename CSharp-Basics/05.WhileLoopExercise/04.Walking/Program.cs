int target = 10000;

int sumOfSteps = 0;
int steps;
while (sumOfSteps < target)
{
    string input = Console.ReadLine();
    if (input == "Going home")
    {   
        input = Console.ReadLine();
        steps = int.Parse(input);
        sumOfSteps += steps;
        break;
    }
    steps = int.Parse(input);
    sumOfSteps += steps;
}

if (sumOfSteps >= target)
{
    Console.WriteLine("Goal reached! Good job!");
    Console.WriteLine($"{sumOfSteps - target} steps over the goal!");
}
if (sumOfSteps < target)
{
    Console.WriteLine($"{target - sumOfSteps} more steps to reach goal.");
}