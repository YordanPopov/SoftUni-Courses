namespace _02.ATM
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int balance = int.Parse(Console.ReadLine());
            int withdraw = int.Parse(Console.ReadLine());
            int limit = int.Parse(Console.ReadLine());

            if (balance >= withdraw && withdraw <= limit)
            {
                Console.WriteLine("The withdraw was successful.");
            }else if (withdraw > limit)
            {
                Console.WriteLine("The limit was exceeded.");
            }
            else if (balance < withdraw)
            {
                Console.WriteLine("Insufficient availability.");
            }
        }
    }
}