namespace GetGreeting
{
    class Program
    {
        static void Main(string[] args)
        {
            GreetingProvider greetingProvider = new GreetingProvider(new SystemTimeProvider());
            string greeting = greetingProvider.GetGreeting();
            Console.WriteLine(greeting);
        }
    }

}