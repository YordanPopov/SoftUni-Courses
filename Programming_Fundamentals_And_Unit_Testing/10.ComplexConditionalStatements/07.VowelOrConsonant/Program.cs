namespace _07.VowelOrConsonant
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char letter = char.Parse(Console.ReadLine());
            bool isVowel = letter == 'a' ||
                           letter == 'A' ||
                           letter == 'e' ||
                           letter == 'E' ||
                           letter == 'i' ||
                           letter == 'I' ||
                           letter == 'o' ||
                           letter == 'O' ||
                           letter == 'u' ||
                           letter == 'U';
            string result = (isVowel) ? "Vowel" : "Consonant";
            Console.WriteLine(result);
        }
    }
}