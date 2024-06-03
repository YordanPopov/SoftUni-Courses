namespace _05.ListManipulationAdvanced
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                                        .Split()
                                        .Select(int.Parse)
                                        .ToList();

            string[] command = Console.ReadLine()
                                      .Split();

            while (command[0] != "end")
            {
                switch (command[0])
                {
                    case "Contains": 
                        CheckNumberExist(command, numbers); 
                        break;
                    case "PrintEven": 
                        PrintEvenNumbers(numbers); 
                        break;
                    case "PrintOdd": 
                        PrintOddNumbers(numbers); 
                        break;
                    case "GetSum": 
                        PrintSumOfNumbers(numbers); 
                        break;
                    case "Filter": 
                        numbers = Filter(command, numbers); 
                        break;
                }
                command = Console.ReadLine().Split();
            }
            Console.WriteLine(string.Join(" ", numbers));
        }

        static void CheckNumberExist(string[] arr, List<int> list)
        {
            int number = int.Parse(arr[1]);

            if (list.Contains(number))
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No such number");
            }
        }
        static void PrintEvenNumbers(List<int> list)
        {
            foreach (int currentNumber in list)
            {
                if (currentNumber % 2 == 0)
                {
                    Console.Write($"{currentNumber} ");
                }
            }

            Console.WriteLine();
        }

        static void PrintOddNumbers(List<int> list)
        {
            foreach (int currentNumber in list)
            {
                if (currentNumber % 2 != 0)
                {
                    Console.Write($"{currentNumber} ");
                }
            }

            Console.WriteLine();
        }

        static void PrintSumOfNumbers(List<int> list)
        {
            int sum = 0;

            foreach (int currentNumber in list)
            {
                sum += currentNumber;
            }

            Console.WriteLine(sum);
        }

        static List<int> Filter(string[] arr, List<int> list)
        {
            string @operator = arr[1];
            int number = int.Parse(arr[2]);
            List<int> filteredList = new List<int>();

            foreach (int currentNumber in list)
            {
                if (@operator == ">" && currentNumber > number)
                {
                    filteredList.Add(currentNumber);
                }
                else if (@operator == "<" && currentNumber < number)
                {
                    filteredList.Add(currentNumber);
                }
                else if (@operator == "<=" && currentNumber <= number)
                {
                    filteredList.Add(currentNumber);
                }
                else if (@operator == ">=" && currentNumber >= number)
                {
                    filteredList.Add(currentNumber);
                }
            }

            return filteredList;
        }
    }
}