int desireHeight = int.Parse(Console.ReadLine());

int startingHeight = desireHeight - 30;
int jumpsCounter = 0;
int negativeJumps = 0;
bool isFail = false;
while (startingHeight <= desireHeight)
{
    int currentJump = int.Parse((Console.ReadLine()));
    jumpsCounter++;
    if (currentJump > startingHeight)
    {
        startingHeight += 5;
    }else if (currentJump <= startingHeight)
    {
        negativeJumps++;
        for (int j = 0; j < 3; j++)
        {
            currentJump = int.Parse(Console.ReadLine());
            if (currentJump > startingHeight)
            {
                jumpsCounter++;
                negativeJumps = 0;
                startingHeight += 5;
                break;
            }
            else
            {
                jumpsCounter++;
                negativeJumps++;
            }
            if (negativeJumps == 3)
            {
                Console.WriteLine($"Tihomir failed at {startingHeight}cm after {jumpsCounter} jumps.");
                isFail = true;
                break;
            }
        }
    }
    if (isFail)
    {
        break;
    }
}
if (startingHeight > desireHeight)
{
    Console.WriteLine($"Tihomir succeeded, he jumped over {startingHeight - 5}cm after {jumpsCounter} jumps.");
}