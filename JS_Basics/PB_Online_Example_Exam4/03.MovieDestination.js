function solve(budget, destination, season, days) {
    const shootingDayPrices = {
        Winter: { Dubai: 45_000, Sofia: 17_000, London: 24_000 },
        Summer: { Dubai: 40_000, Sofia: 12_500, London: 20_250 }
    }

    let price = shootingDayPrices[season][destination] * days;

    if (destination === 'Dubai') {
        price *= 0.7;
    } else if (destination === 'Sofia') {
        price *= 1.25;
    }

    if (budget >= price) {
        let leftMoney = budget - price;
        console.log(`The budget for the movie is enough! We have ${leftMoney.toFixed(2)} leva left!`);
    } else {
        let neededMoney = price - budget;
        console.log(`The director needs ${neededMoney.toFixed(2)} leva more!`)
    }
}

solve(400000, 'Sofia', 'Winter', 20);