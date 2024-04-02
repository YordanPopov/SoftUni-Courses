int hours = int.Parse(Console.ReadLine());
int minutes = int.Parse(Console.ReadLine());

int newHours;
int newMinutes = minutes + 15;

if (newMinutes >= 60)
{
    newHours = (hours + 1) % 24;
    newMinutes = newMinutes % 60;
}
else
{
    newHours = hours;
}
if (newMinutes < 10)
{
    Console.WriteLine($"{newHours}:0{newMinutes}");
}
else
{
    Console.WriteLine($"{newHours}:{newMinutes}");
}
