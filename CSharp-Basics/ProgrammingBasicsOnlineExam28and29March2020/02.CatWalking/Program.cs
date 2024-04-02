int minutesWalkPerDay = int.Parse(Console.ReadLine());
int numberOfWalking = int.Parse(Console.ReadLine());
int caloriesPerDay = int.Parse(Console.ReadLine());

int totalWalksPerDay = numberOfWalking * minutesWalkPerDay;
int caloriesBurned = totalWalksPerDay * 5;

if ( caloriesPerDay * 0.5 <= caloriesBurned)
{
    Console.WriteLine($"Yes, the walk for your cat is enough. Burned calories per day: {caloriesBurned}.");
}
else
{
    Console.WriteLine($"No, the walk for your cat is not enough. Burned calories per day: {caloriesBurned}.");
}