function solve(inheritanceAmount, targetYear) {
    let age = 18;

    for(let currentYear = 1800; currentYear <= targetYear; currentYear++) {
        if (currentYear % 2 === 0) {
            inheritanceAmount -= 12_000;
        } else {
            inheritanceAmount -= 12_000 + (50 * (age + currentYear - 1800));
        }
    }

    if (inheritanceAmount >= 0) {
        console.log(`Yes! He will live a carefree life and will have ${inheritanceAmount.toFixed(2)} dollars left.`);
    } else {
        console.log(`He will need ${Math.abs(inheritanceAmount).toFixed(2)} dollars to survive.`);
    }
}

solve(100000.15, 1808);