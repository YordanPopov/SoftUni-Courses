int bitcoins = int.Parse(Console.ReadLine());
double chineseYuan = double.Parse(Console.ReadLine());
double commission = double.Parse(Console.ReadLine()) / 100;

double totalCashInBgn = (bitcoins * 1168) + ((chineseYuan * 0.15) * 1.76);
double totalCashInEur = totalCashInBgn / 1.95;
double totalCash = totalCashInEur - (totalCashInEur * commission);

Console.WriteLine($"{totalCash:f2}");