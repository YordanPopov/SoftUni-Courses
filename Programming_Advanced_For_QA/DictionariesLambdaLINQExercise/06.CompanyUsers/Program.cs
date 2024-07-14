namespace _06.CompanyUsers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> companies = new();

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] inputArray = input.Split(" -> ");

                string company = inputArray[0];
                string employeeID = inputArray[1];

                if (!companies.ContainsKey(company))
                {
                    companies.Add(company, new List<string>());
                }

                if (!companies[company].Contains(employeeID))
                {
                    companies[company].Add(employeeID);
                }

                input = Console.ReadLine();
            }

            foreach (var currentCompany in companies)
            {
                Console.WriteLine($"{currentCompany.Key}");

                foreach (string employeeID in currentCompany.Value)
                {
                    Console.WriteLine($"-- {employeeID}");
                }
            }
        }
    }
}