namespace _07.CharacterMultiplier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string str1 = input[0];
            string str2 = input[1];

            int maxLength = Math.Max(str1.Length, str2.Length);
            int sum = 0;

            for (int i = 0; i < maxLength; i++)
            {
                if (i >= str1.Length)
                {
                    sum += str2[i];
                }
                else if (i >= str2.Length)
                {
                    sum += str1[i];
                }
                else
                {
                    sum += str1[i] * str2[i];
                }
            }

            Console.WriteLine(sum);
        }
    }
}