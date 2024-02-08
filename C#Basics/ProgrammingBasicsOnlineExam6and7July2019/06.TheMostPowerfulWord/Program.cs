string word = Console.ReadLine();

int maxPoints = int.MinValue;
string strongestWord = "";

while (word != "End of words")
{
    double points = 0;

    for (int i = 0; i < word.Length; i++)
    {
        int currentNumber = (int)word[i];
        points += currentNumber;
    }
    if (word[0] == 'a'
        || word[0] == 'e'
        || word[0] == 'i'
        || word[0] == 'o' 
        || word[0] == 'u'
        || word[0] == 'y'
        || word[0] == 'A'
        || word[0] == 'E'
        || word[0] == 'I'
        || word[0] == 'O'
        || word[0] == 'U'
        || word[0] == 'Y')
    {
        points *= word.Length;
    }
    else
    {
        points /= word.Length;
        points = Math.Round(points);
    }
    if (points > maxPoints)
    {
        maxPoints = (int)points;
        strongestWord = word;
    }
    word = Console.ReadLine();
}
Console.WriteLine($"The most powerful word is {strongestWord} - {maxPoints}");