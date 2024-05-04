namespace _03.BiggestNum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int biggestNumber = int.MinValue;
            for (int i = 0; i < 5; i++)
            {
                int num = int.Parse(Console.ReadLine());
                if (num > biggestNumber)
                {
                    biggestNumber = num;
                }
            }
            Console.WriteLine(biggestNumber);
        }
    }
}