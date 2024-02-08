//input
int lengthOfAquarium = int.Parse(Console.ReadLine());
int widthOfAquarium = int.Parse(Console.ReadLine());
int heightOfAquarium = int.Parse(Console.ReadLine());
double percent = double.Parse(Console.ReadLine())/100;

//calculation
double volumeOfAquariumInLiters = (lengthOfAquarium * widthOfAquarium * heightOfAquarium) * 0.001;
double volumeOfAquariumWithoutSand = volumeOfAquariumInLiters * (1 - percent);

//output
Console.WriteLine(volumeOfAquariumWithoutSand);