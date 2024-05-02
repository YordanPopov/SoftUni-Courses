namespace _06.Aquarium
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Input
            int aquariumLength = int.Parse(Console.ReadLine());
            int aquariumWidth = int.Parse(Console.ReadLine());
            int aquariumHeight = int.Parse(Console.ReadLine());
            double occupiedSpace = double.Parse(Console.ReadLine()) / 100;

            // Calculations
            int aquariumVolume = aquariumHeight * aquariumLength * aquariumWidth;
            double aquariumVolumeInLiters = aquariumVolume * 0.001;
            double requredLiters = aquariumVolumeInLiters * (1 - occupiedSpace);

            // Outputs
            Console.WriteLine($"{requredLiters:f2}");
        }
    }
}