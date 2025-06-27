function solve([budget, seriesCount, ...input]) {
    budget = Number(budget);
    seriesCount = Number(seriesCount);
    let index = 0;
    let spentMoney = 0;

    while (seriesCount > 0) {
        let seriesName = input[index++];
        let seriesPrice = Number(input[index++]);

        switch (seriesName) {
            case 'Thrones': seriesPrice *= 0.5; break;
            case 'Lucifer': seriesPrice *= 0.6; break;
            case 'Protector': seriesPrice *= 0.7; break;
            case 'TotalDrama': seriesPrice *= 0.8; break;
            case 'Area': seriesPrice *= 0.9; break;
        }

        spentMoney += seriesPrice;
        seriesCount--;
    }

    if (budget >= spentMoney) {
        console.log(`You bought all the series and left with ${(budget - spentMoney).toFixed(2)} lv.`);
    } else {
        console.log(`You need ${(spentMoney - budget).toFixed(2)} lv. more to buy the series!`);
    }
}

solve(["10",
    "3",
    "Thrones",
    "5",
    "Riverdale",
    "5",
    "Gotham",
    "2"]);
