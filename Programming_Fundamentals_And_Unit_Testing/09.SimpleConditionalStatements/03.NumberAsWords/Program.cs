namespace _03.NumberAsWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            string result = number switch
            {
                1 => "one",
                2 => "two",
                3 => "three",
                4 => "four",
                5 => "five",
                6 => "six",
                7 => "seven",
                8 => "eight",
                9 => "nine",
                _ => "Out of range"
            };
            Console.WriteLine(result);
        }
    }
}