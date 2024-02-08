int lilyAge = int.Parse(Console.ReadLine());
double priceWashingMachine = double.Parse(Console.ReadLine());    
int priceForToy = int.Parse(Console.ReadLine());

int sum = 0;
int counterToy = 0;
int moneyForBirthDay = 10;


for (int i = 1; i <= lilyAge; i++)
{
    if (i % 2 == 0)
    {
        sum += (moneyForBirthDay - 1);
        moneyForBirthDay += 10;
    }
    else
    {
        counterToy++;
    }
}

sum += counterToy * priceForToy;

if (sum >= priceWashingMachine)
{
    Console.WriteLine($"Yes! {(sum - priceWashingMachine):f2}");
}
else
{
    Console.WriteLine($"No! {(priceWashingMachine - sum):f2}");
}