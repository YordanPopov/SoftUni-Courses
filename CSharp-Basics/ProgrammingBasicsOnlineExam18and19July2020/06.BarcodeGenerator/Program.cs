int startingNumber = int.Parse(Console.ReadLine());
int finalNumber = int.Parse(Console.ReadLine());

for (int firstDigit = startingNumber / 1000 % 10; firstDigit <= finalNumber / 1000 % 10; firstDigit++)
{
    for (int secondDigit = startingNumber / 100 % 10; secondDigit <= finalNumber / 100 % 10; secondDigit++)
    {
        for (int thirdDigit = startingNumber / 10 % 10; thirdDigit <= finalNumber / 10 % 10; thirdDigit++)
        {
            for (int fourthDigit = startingNumber % 10; fourthDigit <= finalNumber % 10; fourthDigit++)
            {
                if (firstDigit % 2 != 0 && secondDigit % 2 != 0 && thirdDigit % 2 != 0 && fourthDigit % 2 != 0)
                {
                    Console.Write($"{firstDigit}{secondDigit}{thirdDigit}{fourthDigit} ");
                }
            }
        }
    }
}