namespace _04.ListManipulationBasics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                                        .Split()
                                        .Select(int.Parse)
                                        .ToList();

            string[] command = Console.ReadLine().Split();

            while (command[0] != "end")
            {
                int number, index;
                if (command[0] == "Add")
                {
                    number = int.Parse(command[1]);
                    AddNumberToTheEndOfList(number, numbers);
                }
                else if (command[0] == "Remove")
                {
                    number = int.Parse(command[1]);
                    RemoveNumberFromList(number, numbers);
                }
                else if (command[0] == "RemoveAt")
                {
                    index = int.Parse(command[1]);
                    RemoveNumberAtIndex(index, numbers);
                }
                else if (command[0] == "Insert")
                {
                    number = int.Parse(command[1]);
                    index = int.Parse(command[2]);
                    InsertNumberInList(number, index, numbers);
                }

                command = Console.ReadLine().Split();
            }
            Console.WriteLine(string.Join(" ", numbers));
        }

        static void AddNumberToTheEndOfList(int number, List<int> numbers)
        {
            numbers.Add(number);
        }

        static void RemoveNumberFromList(int number, List<int> numbers)
        {
            numbers.Remove(number);
        }

        static void RemoveNumberAtIndex(int index, List<int> numbers)
        {
            numbers.RemoveAt(index);
        }

        static void InsertNumberInList(int number, int index, List<int> numbers)
        {
            numbers.Insert(index, number);
        }
    }
}