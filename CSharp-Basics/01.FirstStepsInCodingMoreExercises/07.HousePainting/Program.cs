//input
double houseHeight = double.Parse(Console.ReadLine());
double sideWallLength = double.Parse(Console.ReadLine());
double roofHeight = double.Parse(Console.ReadLine());

//calculations of walls
//walldoor 1.2m * 2m
//windows 1.5
double backAndfrontWallsAreas = ((houseHeight * houseHeight) * 2) - (1.2 * 2);
double sideWallsAreas = ((houseHeight * sideWallLength) * 2) - (2 * (1.5 * 1.5));
double greenPiantForWalls = (backAndfrontWallsAreas + sideWallsAreas) / 3.4;
string formattedGreenPaint = greenPiantForWalls.ToString("0.00");

//calculation of roof
double roofArea = (2 * (houseHeight * sideWallLength)) + (2 * ((houseHeight * roofHeight) / 2));
double redPaintForRoof = roofArea / 4.3;
string formattetRedPaint = redPaintForRoof.ToString("0.00");

//output
Console.WriteLine(formattedGreenPaint);
Console.WriteLine(formattetRedPaint);