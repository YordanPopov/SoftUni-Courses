namespace _09.SumSeconds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstTime = int.Parse(Console.ReadLine()),
                secondTime = int.Parse(Console.ReadLine()),
                thirdTime = int.Parse(Console.ReadLine());
            int totalTime = firstTime + secondTime + thirdTime;
            string result = (totalTime >= 60) ? (totalTime % 60 < 10) ? $"{totalTime / 60}:0{totalTime % 60}" : $"{totalTime / 60}:{totalTime % 60}" 
                          : (totalTime % 60 < 10) ? $"{totalTime / 60}:0{totalTime % 60}" : $"{totalTime / 60}:{totalTime % 60}";
            Console.WriteLine(result);
        }
    }
}