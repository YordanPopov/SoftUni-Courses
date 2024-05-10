namespace _04.Sequence2k_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int sequenceElement = 1;

            while (sequenceElement <= number)
            {
                Console.WriteLine(sequenceElement);
                sequenceElement = 2 * sequenceElement + 1;
            }
        }
    }
}