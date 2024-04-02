//input
double r = double.Parse(Console.ReadLine());
//calculation
double area = Math.PI * r * r;
double parameter = 2 * Math.PI * r;
string formattedArea = area.ToString("0.00");
string formattedParameter = parameter.ToString("0.00");
//output
Console.WriteLine(formattedArea);
Console.WriteLine(formattedParameter); 