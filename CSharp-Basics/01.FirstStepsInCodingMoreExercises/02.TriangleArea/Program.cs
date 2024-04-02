//input
double a = double.Parse(Console.ReadLine());
double h = double.Parse(Console.ReadLine());

//calculation
double triangleArea = a * h / 2;
string formattedTriangleArea = triangleArea.ToString("0.00");

//output
Console.WriteLine(formattedTriangleArea);


