string product = Console.ReadLine();
string city = Console.ReadLine();
double quantity = double.Parse(Console.ReadLine());
double price = 0;

if (city == "Sofia")
{
    if (product == "coffee")
    {
        price = quantity * 0.5;
        Console.WriteLine(price);
    }else if (product == "water")
    {
        price = quantity * 0.8;
        Console.WriteLine(price);
    }else if(product == "beer")
    {
        price = 1.2 * quantity;
        Console.WriteLine($"{price:f1}");
    }
    else if (product == "sweets")
    {
        price = quantity * 1.45;
        Console.WriteLine(price);
    }else if(product == "peanuts")
    {
        price = quantity * 1.6;
        Console.WriteLine(price);
    }
}else if (city == "Plovdiv")
{
    if (product == "coffee")
    {
        price = quantity * 0.4;
        Console.WriteLine(price);
    }
    else if (product == "water")
    {
        price = quantity * 0.7;
        Console.WriteLine(price);
    }
    else if (product == "beer")
    {
        price = quantity * 1.15;
        Console.WriteLine(price);
    }
    else if (product == "sweets")
    {
        price = quantity * 1.3;
        Console.WriteLine(price);
    }
    else if (product == "peanuts")
    {
        price = quantity * 1.5;
        Console.WriteLine(price);
    }
}else if (city == "Varna")
{
    if (product == "coffee")
    {
        price = quantity * 0.45;
        Console.WriteLine(price);
    }
    else if (product == "water")
    {
        price = quantity * 0.7;
        Console.WriteLine(price);
    }
    else if (product == "beer")
    {
        price = quantity * 1.1;
        Console.WriteLine(price);
    } 
    else if (product == "sweets")
    {
        price = quantity * 1.35;
        Console.WriteLine(price);
    }
    else if (product == "peanuts")
    {
        price = quantity * 1.55;
        Console.WriteLine(price);
    }
}

