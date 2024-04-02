//input
double cenaKgSkumriq = double.Parse(Console.ReadLine());
double cenakgCaca = double.Parse(Console.ReadLine());
double kgPalamud = double.Parse(Console.ReadLine());
double kgSafrid = double.Parse(Console.ReadLine());
double kgMidi = double.Parse(Console.ReadLine());

//calculations
double cenaPalamud = (0.6 * cenaKgSkumriq) + cenaKgSkumriq;
double cenaSafrid = (0.8 * cenakgCaca) + cenakgCaca;
double cenaMidi = kgMidi * 7.50;
double testSum =(cenaPalamud * kgPalamud) + (cenaSafrid * kgSafrid) + cenaMidi;
string formattedSum = testSum.ToString("0.00");

//output
Console.WriteLine(formattedSum);