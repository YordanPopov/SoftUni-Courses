//Input
int examHours = int.Parse(Console.ReadLine());
int examMinutes = int.Parse(Console.ReadLine());
int arrivalHours = int.Parse(Console.ReadLine());
int arrivalMinutes = int.Parse(Console.ReadLine());

//Calculations
int examTimeInMinutes = (examHours * 60) + examMinutes;
int arrivalTimeInMinutes = (arrivalHours * 60) + arrivalMinutes;
int differenceInMinutes = examTimeInMinutes - arrivalTimeInMinutes;

if (differenceInMinutes > 30)
{
    Console.WriteLine("Early");
    if (differenceInMinutes >= 60)
    {
        int hoursEarly = differenceInMinutes / 60;
        int minutesEarly = differenceInMinutes - (hoursEarly * 60);
        if (minutesEarly >= 10)
        {
            Console.WriteLine($"{hoursEarly}:{minutesEarly} hours before the start");
        }
        else
        {
            Console.WriteLine($"{hoursEarly}:0{minutesEarly} hours before the start");
        }
        
    }
    else
    {
     Console.WriteLine($"{differenceInMinutes} minutes before the start");
    }
}
else if (differenceInMinutes < 0)
{
    Console.WriteLine("Late");
    differenceInMinutes *= -1;
    if (differenceInMinutes >= 60)
    {
        int hoursEarly = differenceInMinutes / 60;
        int minutesEarly = differenceInMinutes - (hoursEarly * 60);
        if (minutesEarly >= 10)
        {
            Console.WriteLine($"{hoursEarly}:{minutesEarly} hours after the start");
        }
        else
        {
            Console.WriteLine($"{hoursEarly}:0{minutesEarly} hours after the start");
        }

    }
    else
    {
        Console.WriteLine($"{differenceInMinutes} minutes after the start");
    }
}
else
{
    Console.WriteLine("On time");
    if (differenceInMinutes > 0)
    {
        Console.WriteLine($"{differenceInMinutes} minutes before the start");
    }
}
