int numberOfLoads = int.Parse(Console.ReadLine());

int sumOfLoads = 0;
double busPrice = 0;
double truckPrice = 0;
double trainPrice = 0;
int bus = 0;
int truck = 0;
int train = 0;

for (int cargo = 0; cargo < numberOfLoads; cargo++)
{
    int tonOfLoad = int.Parse(Console.ReadLine());
    sumOfLoads += tonOfLoad;
    if (tonOfLoad <= 3)
    {
        busPrice += tonOfLoad * 200;
        bus += tonOfLoad;

    }else if (tonOfLoad >= 4 && tonOfLoad <= 11)
    {
        truckPrice += tonOfLoad * 175;
        truck += tonOfLoad;
    }else if (tonOfLoad >= 12)
    {
        trainPrice += tonOfLoad * 120;
        train += tonOfLoad;
    }
}
double totalPrice = busPrice + truckPrice + trainPrice;
double avrPrice = totalPrice / (double)sumOfLoads;
Console.WriteLine($"{avrPrice:f2}");
Console.WriteLine($"{(double)bus / sumOfLoads * 100:f2}%");
Console.WriteLine($"{(double)truck / sumOfLoads * 100:f2}%");
Console.WriteLine($"{(double)train / sumOfLoads * 100:f2}%");