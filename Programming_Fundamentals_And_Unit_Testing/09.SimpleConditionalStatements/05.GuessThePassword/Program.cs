namespace _05.GuessThePassword
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            string result = (password == "s3cr3t!") ? "Welcome" : "Wrong password!";
            Console.WriteLine(result);
        }
    }
}