namespace _01.CountCharsInString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var charactersCount = new Dictionary<char, int>();

            string[] text = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach (string word in text)
            {
                for (int i = 0; i < word.Length; i++)
                {
                    char currentDigit = word[i];

                    if (charactersCount.ContainsKey(currentDigit))
                    {
                        charactersCount[currentDigit]++;
                    }
                    else
                    {
                        charactersCount.Add(currentDigit, 1);
                    }
                }

            }

            foreach (KeyValuePair<char, int> item in charactersCount)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }

            // Another solution
            //Dictionary<char, int> characters = new();

            //string input = Console.ReadLine();

            //foreach (char ch in input)
            //{
            //    if (char.IsWhiteSpace(ch))
            //    {
            //        continue;
            //    }

            //    if (!characters.ContainsKey(ch))
            //    {
            //        characters.Add(ch, 1);
            //    }
            //    else
            //    {
            //        characters[ch]++;
            //    }
            //}

            //foreach (var character in characters)
            //{
            //    Console.WriteLine($"{character.Key} -> {character.Value}");
            //}
        }
    }
}