namespace GreaterOfTwoValues

{
    public class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            string firstValue = Console.ReadLine();
            string secondValue = Console.ReadLine();


            switch (type)
            {
                case "int":
                    Console.WriteLine(IntCompare(int.Parse(firstValue), int.Parse(secondValue)));
                    break;
                case "char":
                    Console.WriteLine(CharCompare(char.Parse(firstValue), char.Parse(secondValue)));
                    break;
                case "string":
                    Console.WriteLine(StringCompare(firstValue, secondValue));
                    break;
            }

        }

        public static int IntCompare(int firstNumber, int secondNumber)
        {
            return (firstNumber > secondNumber) ? firstNumber : secondNumber;
        }

        public static char CharCompare(char firstCharacter, char secondCharacter)
        {
            return (firstCharacter > secondCharacter) ? firstCharacter : secondCharacter;
            // return
        }

        public static string StringCompare(string firstString, string secondString)
        {
            return (string.Compare(firstString, secondString) > 0) ? firstString : secondString;
        }
    }
}