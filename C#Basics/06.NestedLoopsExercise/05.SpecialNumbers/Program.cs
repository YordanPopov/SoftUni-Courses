int number = int.Parse(Console.ReadLine());

for (int firstDigit = 1111 / 1000 % 10; firstDigit <= 9999 / 1000 % 10; firstDigit++)
{
    for (int secondDigit = 1111 / 100 % 10; secondDigit  <= 9999/ 100 % 10; secondDigit++)
    {
        for (int thirdDigit = 1111 / 10 % 10; thirdDigit <= 9999 / 10 % 10; thirdDigit++)
        {
            for (int fourthDigit = 1111 % 10; fourthDigit <= 9999 % 10; fourthDigit++)
            {
                if (number % firstDigit == 0 && number % secondDigit == 0 && number % thirdDigit == 0 && number % fourthDigit == 0)
                {
                    Console.Write($"{firstDigit}{secondDigit}{thirdDigit}{fourthDigit} ");
                }
            }
        }
    }
}