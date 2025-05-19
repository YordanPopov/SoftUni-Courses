function solve(budget, extrasCount, clothingPrice) {
    let decorPrice = budget * 0.1;

    if (extrasCount >= 150) {
        clothingPrice *= 0.9;
    }

    let totalExpense = (extrasCount * clothingPrice) + decorPrice;

    if (totalExpense <= budget) {
        console.log(`Action!\nWingard starts filming with ${(budget - totalExpense).toFixed(2)} leva left.`);
    } else {
        console.log(`Not enough money!\nWingard needs ${(totalExpense - budget).toFixed(2)} leva more.`);
    }
}

solve(20000, 120, 55.5);