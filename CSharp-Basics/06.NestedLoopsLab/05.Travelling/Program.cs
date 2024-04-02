using System;

public class Program
{
    public static void Main()
    {
        double sum = 0;
        while (true)
        {
            string destination = Console.ReadLine();
            if (destination == "End")
            {
                break;
            }
            double budget = double.Parse(Console.ReadLine());
            while (true)
            {
                double savedMoney = double.Parse(Console.ReadLine());
                sum += savedMoney;
                if (sum >= budget)
                {
                    Console.WriteLine("Going to {0}!", destination);
                    sum = 0;
                    break;
                }
            }
        }
        //Console.WriteLine("Hello World");
    }
}