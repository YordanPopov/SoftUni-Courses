namespace _08.ExtractFile
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = Console.ReadLine();

            int extensionIndex = path.LastIndexOf(".");
            int fileNameIndex = path.LastIndexOf("\\");

            string extension = string.Empty;
            string fileName = string.Empty;

            for (int i = extensionIndex + 1; i < path.Length; i++)
            {
                extension += path[i];
            }

            for (int i = fileNameIndex + 1; i < extensionIndex; i ++)
            {
                fileName += path[i];
            }

            Console.WriteLine($"File name: {fileName}");
            Console.WriteLine($"File extension: {extension}");

        }
    }
}