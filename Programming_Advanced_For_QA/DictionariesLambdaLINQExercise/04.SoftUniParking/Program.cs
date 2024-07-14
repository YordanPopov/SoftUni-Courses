namespace _04.SoftUniParking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> users = new();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] commandArray = Console.ReadLine()
                    .Split()
                    .ToArray();

                string command = commandArray[0];
                string employee = commandArray[1];
                

                if (command == "register")
                {
                    string plateNumber = commandArray[2];

                    if (!users.ContainsKey(employee))
                    {
                        users.Add(employee, plateNumber);
                        Console.WriteLine($"{employee} registered {plateNumber} successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {users[employee]}");
                    }
                }
                else if (command == "unregister")
                {
                    if (users.ContainsKey(employee))
                    {
                        users.Remove(employee);
                        Console.WriteLine($"{employee} unregistered successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: user {employee} not found");
                    }
                }
            }

            foreach (var user in users)
            {
                Console.WriteLine($"{user.Key} => {user.Value}");
            }
        }
    }
}