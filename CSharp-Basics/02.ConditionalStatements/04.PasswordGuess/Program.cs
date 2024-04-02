using System.Runtime.InteropServices;

string myPass = "s3cr3t!P@ssw0rd";
string inputPass = Console.ReadLine();

if (inputPass == myPass)
{
    Console.WriteLine("Welcome");
}
else
{
    Console.WriteLine("Wrong password!");
}