namespace teoreticalExam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int a = 5;
            //int b = a++;
            //int c = ++a;

            //Console.WriteLine(c);

            //bool isTrue = 100 == 100;
            //Console.WriteLine(isTrue);
            //PrintText("C#");

            for (int i = 10; i > 3; i -= 2)
            {
                Console.Write($"{i} ");
            }
        }

        static void PrintText(string text)
        {
            Console.WriteLine("I love" + text);
        }
    }
}