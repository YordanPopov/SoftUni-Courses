using System.Reflection;

int wallHeight = int.Parse(Console.ReadLine());
int wallWidth = int.Parse(Console.ReadLine());  
double percetageUnpaintArea = double.Parse(Console.ReadLine()) / 100;

double paintArea = wallHeight * wallWidth * 4;
paintArea = paintArea - (paintArea * percetageUnpaintArea);
paintArea = Math.Ceiling(paintArea);
double leftPaint = 0;
bool isPaint = false;
string litersPaint = Console.ReadLine();

while (litersPaint != "Tired!")
{
    int paint = int.Parse(litersPaint);
    paintArea -= paint;
    if (paintArea <= 0)
    {
        isPaint = true;
        break;
    }
    litersPaint = Console.ReadLine();
}
if (!isPaint)
{
    Console.WriteLine($"{paintArea} quadratic m left.");
}
else
{
    if (paintArea < 0)
    {
        Console.WriteLine($"All walls are painted and you have {Math.Abs(paintArea)} l paint left!");
    }
    else
    {
        Console.WriteLine("All walls are painted! Great job, Pesho!");
    }
}
