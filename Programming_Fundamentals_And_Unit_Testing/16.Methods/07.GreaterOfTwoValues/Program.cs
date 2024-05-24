namespace _07.GreaterOfTwoValues
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            string firstValue = Console.ReadLine();
            string secondValue = Console.ReadLine();


            switch (type)
            {
                case "int":
                    int firstNumber = int.Parse(firstValue);
                    int secondNumber = int.Parse(secondValue);
                    Console.WriteLine(IntCompare(firstNumber, secondNumber)); 
                    break;
                case "char":
                    char firstCharacter = char.Parse(firstValue);
                    char secondCharacter = char.Parse(secondValue);
                    Console.WriteLine(CharCompare(firstCharacter, secondCharacter));
                    break;
                case "string":
                    Console.WriteLine(StringCompare(firstValue, secondValue));
                    break;
            }
        }
        static int IntCompare(int firstNumber, int secondNumber)
        {
           return (firstNumber > secondNumber) ? firstNumber : secondNumber;
        }

        static char CharCompare(char firstCharacter, char secondCharacter)
        {
            return (firstCharacter > secondCharacter) ? firstCharacter : secondCharacter;
        }

        static string StringCompare(string firstString, string secondString)
        {
            return (string.Compare(firstString, secondString) > 0) ? firstString : secondString;
        }
    }
}