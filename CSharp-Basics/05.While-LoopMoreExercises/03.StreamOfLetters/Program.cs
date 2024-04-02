string input = Console.ReadLine();

string word = "";
int counterC = 0;
int counterO = 0;
int counterN = 0;
int wordCounter = 0;
bool isSecretLetter = false;

while (input != "End")
{
    char letter = char.Parse(input);
    if ((letter >= 'a' && letter <= 'z') || (letter >= 'A' && letter <= 'Z'))
    {
        if (letter == 'c' && counterC < 1)
        {
            counterC++;
            wordCounter++;
            isSecretLetter = true;
        }else if (letter == 'o' && counterO < 1)
        {
            counterO++;
            wordCounter++;
            isSecretLetter = true;
        }else if (letter == 'n' && counterN < 1)
        {
            counterN++;
            wordCounter++;
            isSecretLetter = true;
        }
        if (wordCounter == 3)
        {
            Console.Write($"{word} ");
            counterC = 0;
            counterO = 0;  
            counterN = 0;  
            wordCounter = 0;
            word = "";
        }else if (!isSecretLetter)
        {
            word += letter;
        }
        isSecretLetter = false;
    }
    input = Console.ReadLine();
}
if (input == "End" && wordCounter == 3)
{
    Console.WriteLine($"{word}");
}
