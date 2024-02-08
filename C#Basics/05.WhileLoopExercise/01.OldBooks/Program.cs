string wantedBook = Console.ReadLine();

int countOfBooks = 0;
bool isBookFound = false;
string nextBookName = Console.ReadLine();

while (nextBookName != "No More Books")
{
    if (nextBookName == wantedBook)
    {
        isBookFound = true;
        break;
    }
    countOfBooks++;
    nextBookName = Console.ReadLine();
}

if (isBookFound)
{
    Console.WriteLine($"You checked {countOfBooks} books and found it.");
}
else
{
    Console.WriteLine($"The book you search is not here!");
    Console.WriteLine($"You checked {countOfBooks} books.");
}