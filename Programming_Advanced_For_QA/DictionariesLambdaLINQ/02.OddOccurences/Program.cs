namespace _02.OddOccurences
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> words = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.ToLower())
                .ToList();

            Dictionary<string, int> dictionaryToLowerWords = new();
            
            foreach (string word in words)
            {
                if (dictionaryToLowerWords.ContainsKey(word))
                {
                    dictionaryToLowerWords[word]++;
                }
                else
                {
                    dictionaryToLowerWords.Add(word, 1);
                }
            }

            foreach (KeyValuePair<string, int> item in dictionaryToLowerWords)
            {
                if (item.Value % 2 == 1)
                {
                    Console.Write($"{item.Key} ");
                }
            }
        }
    }
}