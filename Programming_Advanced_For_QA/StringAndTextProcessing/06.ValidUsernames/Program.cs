using System.Net.Sockets;

namespace _06.ValidUsernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] userNames = Console.ReadLine().Split(", ");

            foreach (string username in userNames)
            {
                if (ValidLength(username) && ValidSymbols(username))
                {
                    Console.WriteLine(username);
                }
            }
        }

        static bool ValidLength(string username)
        {
            if (username.Length >= 3 && 16 >= username.Length)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static bool ValidSymbols(string username)
        {
            bool isValid = false;

            foreach (char c in username)
            {
                if ((char.IsLetterOrDigit(c)) || c == '-' || c == '_')
                {
                    isValid = true;
                }
                else
                {
                    return false;
                }
            }

            return isValid;
        }
    }
}