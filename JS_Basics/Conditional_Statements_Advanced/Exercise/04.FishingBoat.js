function solve(budget, season, fishermen) {
    const boatPrices = {
        "Spring": 3000,
        "Summer": 4200,
        "Autumn": 4200,
        "Winter": 2600
    };

    let totalCost = boatPrices[season];
    if (fishermen <= 6) {
        totalCost *= 0.90;
    } else if (fishermen <= 11) {
        totalCost *= 0.85;
    } else if (fishermen >= 12) {
        totalCost *= 0.75;
    }

    if (fishermen % 2 === 0 && season !== "Autumn") {
        totalCost *= 0.95;
    }

    if (budget >= totalCost) {
        console.log(`Yes! You have ${(budget - totalCost).toFixed(2)} leva left.`);
    } else {
        console.log(`Not enough money! You need ${(totalCost - budget).toFixed(2)} leva.`);
    }
}

solve(3000, 'Summer', 11);