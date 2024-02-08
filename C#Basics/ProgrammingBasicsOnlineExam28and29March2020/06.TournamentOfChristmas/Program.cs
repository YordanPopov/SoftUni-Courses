int daysOfTournament = int.Parse(Console.ReadLine());

double totalRaisedMoney = 0;
int wins = 0;
int lose = 0;

for (int day = 1; day <= daysOfTournament; day++)
{
    string sport = Console.ReadLine();
    int winsPerDay = 0;
    int losePerDay = 0;
    double raisedMoneyPerDay = 0;

    while (sport != "Finish")
    {
        string result = Console.ReadLine();
        
        if (result == "win")
        {
            winsPerDay++;
            wins++;
            raisedMoneyPerDay += 20;
        }
        else if (result == "lose")
        {
            losePerDay++;
            lose++;
        }
        sport = Console.ReadLine();
    }
    if (winsPerDay > losePerDay)
    {
        raisedMoneyPerDay *= 1.1;
        totalRaisedMoney += raisedMoneyPerDay;
    }
    else
    {
        totalRaisedMoney += raisedMoneyPerDay;
    }
}
if (wins > lose)
{
    totalRaisedMoney *= 1.2;
    Console.WriteLine($"You won the tournament! Total raised money: {totalRaisedMoney:f2}");
}
else
{
    Console.WriteLine($"You lost the tournament! Total raised money: {totalRaisedMoney:f2}");
}

