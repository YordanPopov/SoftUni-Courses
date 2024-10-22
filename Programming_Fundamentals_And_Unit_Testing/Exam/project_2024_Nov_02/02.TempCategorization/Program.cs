namespace _02.TempCategorization
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dailyTemp = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            List<int> lessThanAvr = new List<int>();
            List<int> moreThanAvr = new List<int>();

            double totalTemp = 0.0;

            for (int i = 0; i < dailyTemp.Length; i++)
            {
                totalTemp += dailyTemp[i];
            }

            double avrTemp = totalTemp / dailyTemp.Length;

            foreach (int temp in dailyTemp)
            {
                if (temp < avrTemp)
                {
                    lessThanAvr.Add(temp);
                }
                else
                {
                    moreThanAvr.Add(temp);
                }
            }

            Console.WriteLine(string.Join(" ", lessThanAvr));
            Console.WriteLine(string.Join(" ", moreThanAvr));
        }
    }
}