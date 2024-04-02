//Input
int number1 = int.Parse(Console.ReadLine());
int number2 = int.Parse(Console.ReadLine());   
char operation = char.Parse(Console.ReadLine());

//Calculations
double result = 0;
string parity = "";

if (operation == '+')
{
    result = number1 + number2;
    if (result % 2 == 0)
    {
        parity = "even";
    }
    else
    {
        parity = "odd";
    }
    Console.WriteLine($"{number1} + {number2} = {result} - {parity}");
} else if (operation == '-')
{
    result = number1 - number2;
    if (result % 2 == 0)
    {
        parity = "even";
    }
    else
    {
        parity = "odd";
    }
    Console.WriteLine($"{number1} - {number2} = {result} - {parity}");
} else if (operation == '*')
{
    result = number1 * number2;
    if (result % 2 == 0)
    {
        parity = "even";
    }
    else
    {
        parity = "odd";
    }
    Console.WriteLine($"{number1} * {number2} = {result} - {parity}");
}else if (operation == '/')
{
    if (number2 != 0)
    {
        result = (double)number1 / number2;
        Console.WriteLine($"{number1} / {number2} = {result:f2}");
    }
    else
    {
        Console.WriteLine($"Cannot divide {number1} by zero");
    }
}else if (operation == '%')
{
    if (number2 != 0)
    {
        result = number1 % number2;
        Console.WriteLine($"{number1} % {number2} = {result}");
    }
    else
    {
        Console.WriteLine($"Cannot divide {number1} by zero");
    }
}

