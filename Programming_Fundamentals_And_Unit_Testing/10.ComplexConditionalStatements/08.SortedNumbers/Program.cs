namespace _08.SortedNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());

            bool isAscending = (num1 < num2) &&
                               (num1 < num3) &&
                               (num2 < num3);
            bool isDecending = (num1 > num2) &&
                               (num1 > num3) &&
                               (num2 > num3);
            string result = (isAscending) ? "Ascending" : (isDecending) ? "Descending" : "Not sorted";
            Console.WriteLine(result);
        }
        
    }
}