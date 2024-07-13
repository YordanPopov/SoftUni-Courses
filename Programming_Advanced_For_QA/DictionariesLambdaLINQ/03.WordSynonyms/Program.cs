namespace _03.WordSynonyms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, List<string>> dictionarySynonyms = new ();

            for (int i = 0; i < n; i++)
            {
                string word = Console.ReadLine();
                string synonym = Console.ReadLine();

                if (dictionarySynonyms.ContainsKey(word))
                {
                    dictionarySynonyms[word].Add(synonym);
                }
                else
                {
                    dictionarySynonyms.Add(word, new List<string> { synonym });
                }
            }

            foreach (KeyValuePair<string, List<string>> item in dictionarySynonyms)
            {
                Console.WriteLine($"{item.Key} - {string.Join(", ", item.Value)}");
            }

        }
    }
}