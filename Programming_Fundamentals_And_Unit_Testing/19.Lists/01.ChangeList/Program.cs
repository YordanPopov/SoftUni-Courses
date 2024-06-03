namespace _01.ChangeList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List <int> numbers = Console.ReadLine()
                                        .Split()
                                        .Select(int.Parse)
                                        .ToList();

            string[] command = Console.ReadLine().Split();

            while (command[0] != "end")
            {
                string operation = command[0];
                int element = int.Parse(command[1]);

                if (operation == "Delete")
                {
                    DeleteElementFromList(element, numbers);
                }
                else if (operation == "Insert")
                {
                    InsertElementIntoList(command, element, numbers);
                }

                command = Console.ReadLine().Split();
            }

            Console.WriteLine(string.Join(" ", numbers));
        }

        static void DeleteElementFromList(int element, List <int> list)
        {
            while (list.Contains(element))
            {
                list.Remove(element);
            }
        }

        static void InsertElementIntoList(string[] arr, int element, List <int> list)
        {
            int position = int.Parse(arr[2]);
            list.Insert(position, element);
        }
    }
}