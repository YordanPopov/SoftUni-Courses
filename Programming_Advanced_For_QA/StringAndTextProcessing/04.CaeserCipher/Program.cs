namespace _04.CaeserCipher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string encryptedText = string.Empty;

            foreach (char letter in text)
            {
                int digit = (int)letter;
                int encDigit = digit + 3;
                char encLetter = (char)encDigit;
                encryptedText += encLetter;
            }

            Console.WriteLine(encryptedText);

        }
    }
}