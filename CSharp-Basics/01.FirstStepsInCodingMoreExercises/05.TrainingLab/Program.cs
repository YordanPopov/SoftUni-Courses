//input
double length = double.Parse(Console.ReadLine()) * 100;
double width = double.Parse(Console.ReadLine()) * 100;

//calculations
    double deskInRow = (width - 100) / 70;
    int intDeskInRow = (int)deskInRow;
    double rows = length / 120;
    int intRows = (int)rows;
    int totalPlaces = (intDeskInRow * intRows) - 3;

    //output
    Console.WriteLine(totalPlaces);