namespace _04.LetterCombinations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char startLetter = char.Parse(Console.ReadLine());
            char endLetter = char.Parse(Console.ReadLine());
            char excudedLetter = char.Parse(Console.ReadLine());
            int counterOfCombinations = 0;

            for (char ch1 = startLetter; ch1 <= endLetter; ch1++)
            {
                for (char ch2 = startLetter; ch2 <= endLetter; ch2++)
                {
                    for (char ch3 = startLetter; ch3 <= endLetter; ch3++)
                    {
                        if (ch1 != excudedLetter && ch2 != excudedLetter && ch3 != excudedLetter)
                        {
                            counterOfCombinations++;
                            Console.Write("{0}{1}{2} ", ch1, ch2, ch3);
                        }
                    }

                }
            }
            Console.WriteLine();
            Console.WriteLine(counterOfCombinations);
        }
    }
}