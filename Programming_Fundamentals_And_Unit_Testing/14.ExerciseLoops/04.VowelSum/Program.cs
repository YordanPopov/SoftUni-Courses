namespace _04.VowelSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int vowelSum = 0;

            for (int i = 0; i < n; i++)
            {
                char character = char.Parse(Console.ReadLine());
                vowelSum += (character == 'a') ? 1 :
                            (character == 'e') ? 2 :
                            (character == 'i') ? 3 :
                            (character == 'o') ? 4 :
                            (character == 'u') ? 5 : 0;
            }
            Console.WriteLine(vowelSum);
        }
    }
}