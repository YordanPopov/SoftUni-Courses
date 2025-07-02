function solve(budget, nights, nightPrice, additionalCostPercent) {
    let additionalCost = additionalCostPercent / 100 * budget;

    if (nights > 7) {
        nightPrice *= 0.95;
    }

    let totalCost = additionalCost + (nights * nightPrice);

    if (totalCost > budget) {
        console.log(`${(totalCost - budget).toFixed(2)} leva needed.`)
    } else {
        console.log(`Ivanovi will be left with ${(budget - totalCost).toFixed(2)} leva after vacation.`);
    }
}

solve(500, 7, 66, 15);