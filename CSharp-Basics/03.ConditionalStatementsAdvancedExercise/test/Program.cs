using System;

class Program
{
    static void Main()
    {
        // Въвеждане на числата и оператора
        int N1 = int.Parse(Console.ReadLine());
        int N2 = int.Parse(Console.ReadLine());
        char operation = char.Parse(Console.ReadLine());

        // Изчисляване на резултата в зависимост от оператора
        double result = 0;

        switch (operation)
        {
            case '+':
                result = N1 + N2;
                Console.WriteLine($"{N1} + {N2} = {result} - {IsEven(result)}");
                break;
            case '-':
                result = N1 - N2;
                Console.WriteLine($"{N1} - {N2} = {result} - {IsEven(result)}");
                break;
            case '*':
                result = N1 * N2;
                Console.WriteLine($"{N1} * {N2} = {result} - {IsEven(result)}");
                break;
            case '/':
                if (N2 != 0)
                {
                    result = (double)N1 / N2;
                    Console.WriteLine($"{N1} / {N2} = {result:F2}");
                }
                else
                {
                    Console.WriteLine($"Cannot divide {N1} by zero");
                }
                break;
            case '%':
                if (N2 != 0)
                {
                    result = N1 % N2;
                    Console.WriteLine($"{N1} % {N2} = {result}");
                }
                else
                {
                    Console.WriteLine($"Cannot divide {N1} by zero");
                }
                break;
            default:
                Console.WriteLine("Invalid operator");
                break;
        }
    }

    // Помощна функция за проверка дали число е четно или нечетно
    static string IsEven(double number)
    {
        return number % 2 == 0 ? "even" : "odd";
    }
}
