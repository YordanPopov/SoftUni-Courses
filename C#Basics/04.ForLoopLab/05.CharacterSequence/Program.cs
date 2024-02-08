using System;

public class Program
{
    public static void Main()
    {
        string text = Console.ReadLine();

        for (int i = 0; i < text.Length; i++)
        {
            char c = text[i];
            Console.WriteLine("{0}", c);
        }
    }
}