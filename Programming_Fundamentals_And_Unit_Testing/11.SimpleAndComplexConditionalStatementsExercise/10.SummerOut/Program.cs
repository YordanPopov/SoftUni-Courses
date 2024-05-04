namespace _10.SummerOut
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int temperature = int.Parse(Console.ReadLine());
            string timeOfDay = Console.ReadLine();

            bool isCool = temperature >= 10 && temperature <= 18,
                 isWarm = temperature > 18 && temperature <= 24,
                 isHot = temperature >= 25;
           string clothing = timeOfDay switch
            {
                "Morning" => (isCool) ? "Sweatshirt" : (isWarm) ? "Shirt" : (isHot) ? "T-Shirt" : "",
                "Afternoon" => (isCool) ? "Shirt" : (isWarm) ? "T-Shirt" : (isHot) ? "Swim Suit" : "",
                "Evening" => "Shirt"
            };
           string shoes = timeOfDay switch
            {
                "Morning" => (isCool) ? "Sneakers" : (isWarm) ? "Moccasins" : (isHot) ? "Sandals" : "",
                "Afternoon" => (isCool) ? "Moccasins" : (isWarm) ? "Sandals" : (isHot) ? "Barefoot" : "",
                "Evening" => "Moccasins"
            };
            Console.WriteLine($"It's {temperature} degrees, get your {clothing} and {shoes}.");
        }
    }
}