function solve(people, entryFee, sunLoungerPrice, umbrellaPrice) {
    let totalEntryFee = people * entryFee;
    let totalSunLoungerCost = Math.ceil(people * 0.75) * sunLoungerPrice;
    let totalUmbrellaCost = Math.ceil(people / 2) * umbrellaPrice;
    let totalCost = totalEntryFee + totalSunLoungerCost + totalUmbrellaCost;

    console.log(`${totalCost.toFixed(2)} lv.`)
}

solve(21, 5.50, 4.40, 6.20);