namespace _09.PasswordValidator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            bool isValidLength = PasswordLength(password);
            bool isConsistOnlyLettersAndDigits = ConsistLetterAndDigits(password);
            bool isMoreThanTwoDigits = MoreThanTwoDigits(password);

            if (isValidLength && isMoreThanTwoDigits && isConsistOnlyLettersAndDigits)
            {
                Console.WriteLine("Password is valid");
            }
            else
            {
                if (!isValidLength)
                {
                    Console.WriteLine("Password must be between 6 and 10 characters");
                }
                if (!isConsistOnlyLettersAndDigits)
                {
                    Console.WriteLine("Password must consist only of letters and digits");
                }
                if (!isMoreThanTwoDigits)
                {
                    Console.WriteLine("Password must have at least 2 digits");
                }
            }
        }
        static bool PasswordLength(string text)
        {
            bool length = (text.Length >= 6 && text.Length <= 10) ? true : false;

            return length;
        }

        static bool ConsistLetterAndDigits(string text)
        {
            bool letterAndDigits = true;

            for (int i = 0; i < text.Length; i++)
            {
                char digit = text[i];

                if (!Char.IsLetterOrDigit(digit))
                {
                    letterAndDigits = false;
                }

            }

            return letterAndDigits;
        }

        static bool MoreThanTwoDigits(string text)
        {
            bool moreThanTwoDigits = false;
            int countDigits = 0;

            for (int i = 0; i < text.Length; i++)
            {
                char digit = text[i];

                if (char.IsDigit(digit))
                {
                    countDigits++;
                }
                if (countDigits >= 2)
                {
                    moreThanTwoDigits = true;
                    break;
                }

            }

            return moreThanTwoDigits;
        }
    }
}