function solve(tripPrice, puzzlesCount, dollsCount, bearsCount, minionsCount, trucksCount) {
    let puzzlePrice = 2.60;
    let dollPrice = 3;
    let bearPrice = 4.10;
    let minionPrice = 8.20;
    let truckPrice = 2;

    let totalPrice = (puzzlesCount * puzzlePrice) + (dollsCount * dollPrice) + (bearsCount * bearPrice) + (minionsCount * minionPrice) + (trucksCount * truckPrice);
    let totalToysCount = puzzlesCount + dollsCount + bearsCount + minionsCount + trucksCount;

    if (totalToysCount >= 50) {
        totalPrice *= 0.75;
    }

    totalPrice *= 0.9;

    if (tripPrice <= totalPrice) {
        console.log(`Yes! ${(totalPrice - tripPrice).toFixed(2)} lv left.`);
    } else {
        console.log(`Not enough money! ${(tripPrice - totalPrice).toFixed(2)} lv needed.`);
    }
}

solve(40.8, 20, 25, 30, 50, 10);