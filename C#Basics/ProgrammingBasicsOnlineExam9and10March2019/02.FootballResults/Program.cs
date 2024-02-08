int win = 0, drawn = 0, lose = 0 ;
for (int i = 0; i < 3; i++)
{
    string result = Console.ReadLine();
    if (result[0] > result[2])
    {
        win++;
    }else if (result[0] == result[2]){
        drawn++;
    }else if (result[0] < result[2]){
        lose++;
    }
}
Console.WriteLine($"Team won {win} games.");
Console.WriteLine($"Team lost {lose} games.");
Console.WriteLine($"Drawn games: {drawn}");