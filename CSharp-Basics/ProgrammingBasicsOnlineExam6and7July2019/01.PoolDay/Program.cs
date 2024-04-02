int people = int.Parse(Console.ReadLine()); 
double entryFee = double.Parse(Console.ReadLine());
double pricePerSunLonger = double.Parse(Console.ReadLine());    
double pricePerUmbrella = double.Parse(Console.ReadLine());

double totalPriceEntry = people * entryFee;
double peopleWithSunLonger = Math.Ceiling(people * 0.75);
double peopleWithUmbrella = Math.Ceiling(people * 0.5);
double totalPrice = totalPriceEntry + (peopleWithSunLonger * pricePerSunLonger) + (peopleWithUmbrella * pricePerUmbrella);

Console.WriteLine($"{totalPrice:f2} lv.");