﻿using System;

public class Program
{
    public static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        int current = 1;
        bool isBigger = false;
        for (int rows = 1; rows <= number; rows++)
        {
            for (int cols = 1; cols <= rows; cols++)
            {
                if (current > number)
                {
                    isBigger = true;
                    break;
                }
                Console.Write(current + " ");
                current++;
            }
            if (isBigger)
            {
                break;
            }
            Console.WriteLine();
        }
        //Console.WriteLine("Hello World");
    }
}