int gameMoves = int.Parse(Console.ReadLine());

double sumOfNumbers = 0;
int numberFrom0to9 = 0;
int numberFrom10to19 = 0;
int numberFrom20to29 = 0;
int numberFrom30to39 = 0;
int numberFrom40to50 = 0;
int invalidNumber = 0;


for (int i = 0; i < gameMoves; i++)
{
    int number = int.Parse(Console.ReadLine());
    if (number >= 0 && number <= 9)
    {
        sumOfNumbers += (number * 0.2);
        numberFrom0to9++;
    }else if (number >= 10 && number <= 19)
    {
        sumOfNumbers += number * 0.3;
        numberFrom10to19++;
    }else if (number >= 20 && number <= 29)
    {
        sumOfNumbers += number * 0.4;
        numberFrom20to29++; 
    }else if (number >= 30 && number <= 39)
    {
        sumOfNumbers += 50;
        numberFrom30to39++;
    }else if (number >= 40 && number <= 50)
    {
        sumOfNumbers += 100;
        numberFrom40to50++;
    }else if(number < 0 || number > 50)
    {
       sumOfNumbers = sumOfNumbers / 2;
        invalidNumber++;
    }
}

Console.WriteLine($"{sumOfNumbers:f2}");
Console.WriteLine($"From 0 to 9: {(double)numberFrom0to9 / gameMoves * 100:f2}%");
Console.WriteLine($"From 10 to 19: {(double)numberFrom10to19 / gameMoves * 100:f2}%");
Console.WriteLine($"From 20 to 29: {(double)numberFrom20to29 / gameMoves * 100:f2}%");
Console.WriteLine($"From 30 to 39: {(double)numberFrom30to39 / gameMoves * 100:f2}%");
Console.WriteLine($"From 40 to 50: {(double)numberFrom40to50 / gameMoves * 100:f2}%");
Console.WriteLine($"Invalid numbers: {(double)invalidNumber / gameMoves * 100:f2}%");