string username = Console.ReadLine();
string password = Console.ReadLine();   

//string input  = Console.ReadLine();

//while (input != password)
//{
//    input = Console.ReadLine();
//}
//Console.WriteLine($"Welcome {username}!");

while (true)
{
    string input = Console.ReadLine();
    if (input == password)
    {
        break;
    }
}
Console.WriteLine($"Welcome {username}!");