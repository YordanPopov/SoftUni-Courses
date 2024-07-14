namespace _02.AMinerTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> resourses = new();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "stop")
            {
                string resourse = command;
                int quantity = int.Parse(Console.ReadLine());

                if (resourses.ContainsKey(resourse))
                {
                    resourses[resourse] += quantity;
                }
                else
                {
                    resourses.Add(resourse, quantity);
                }
            }

            foreach (KeyValuePair<string, int> item in resourses)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }           
        }
    }
}