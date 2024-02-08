int month = int.Parse(Console.ReadLine());

double totalElectricityBill = 0;
double waterBill = 20;
double internetBill = 15;
double otherBill = 0;
for (int i = 0; i < month; i++)
{
    double ElectricityBill = double.Parse(Console.ReadLine());
    totalElectricityBill += ElectricityBill;
    otherBill += (ElectricityBill + waterBill + internetBill) + ((ElectricityBill + waterBill + internetBill) * 0.2);

}
double avrSum = (totalElectricityBill + otherBill + (waterBill * month) + (internetBill * month)) / month;
Console.WriteLine($"Electricity: {totalElectricityBill:f2} lv");
Console.WriteLine($"Water: {waterBill * month:f2} lv");
Console.WriteLine($"Internet: {internetBill * month:f2} lv");
Console.WriteLine($"Other: {otherBill:f2} lv");
Console.WriteLine($"Average: {avrSum:f2} lv");
