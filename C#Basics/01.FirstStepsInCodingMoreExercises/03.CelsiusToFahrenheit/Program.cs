//input
double degreesCelsius = double.Parse(Console.ReadLine());

//calculation
double celsiusToFahrenheit = (degreesCelsius * 1.8) + 32;
string formattedCelsiusToFahrenheit = celsiusToFahrenheit.ToString("0.00");

//output
Console.WriteLine(formattedCelsiusToFahrenheit);