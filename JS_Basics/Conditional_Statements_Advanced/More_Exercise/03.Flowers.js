function solve(chrysanthemumsCount, rosesCount, tulipsCount, season, isHoliday) {
    let chrysanthemumsPrice;
    let rosesPrice;
    let tulipsPrice;
    let totalFlowers = chrysanthemumsCount + rosesCount + tulipsCount;

    switch (season) {
        case 'Spring':
        case 'Summer':
            chrysanthemumsPrice = 2.00;
            rosesPrice = 4.10;
            tulipsPrice = 2.50;
            break;
        case 'Autumn':
        case 'Winter':
            chrysanthemumsPrice = 3.75;
            rosesPrice = 4.50;
            tulipsPrice = 4.15;
            break;
    }

    let totalCost = (chrysanthemumsCount * chrysanthemumsPrice) + (rosesCount * rosesPrice) + (tulipsCount * tulipsPrice);
    if (isHoliday === 'Y') {
        totalCost *= 1.15;
    }

    if (tulipsCount > 7 && season === 'Spring') {
        totalCost *= 0.95;
    }
    if (rosesCount >= 10 && season === 'Winter') {
        totalCost *= 0.9;
    }
    if (totalFlowers > 20) {
        totalCost *= 0.8;
    }

    totalCost += 2;
    console.log(totalCost.toFixed(2));
}

solve(10, 10, 10, 'Autumn', 'N');