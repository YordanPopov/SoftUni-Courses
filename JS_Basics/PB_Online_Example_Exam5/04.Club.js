function solve([desiredProfit, ...input]) {
    desiredProfit = Number(desiredProfit);
    let totalProfit = 0;

    let index = 0;
    while (input[index] !== 'Party!') {
        let cocktailName = input[index++];
        let cocktailsCount = Number(input[index++]);

        let cocktailPrice = cocktailName.length;
        let totalCost = cocktailPrice * cocktailsCount;

        if (totalCost % 2 !== 0) {
            totalCost *= 0.75;
        }

        totalProfit += totalCost;
        if (totalProfit >= desiredProfit) {
            console.log(`Target acquired.`);
            console.log(`Club income - ${totalProfit.toFixed(2)} leva.`);
            return;
        }
    }

    console.log(`We need ${(desiredProfit - totalProfit).toFixed(2)} leva more.`);
    console.log(`Club income - ${totalProfit.toFixed(2)} leva.`);
}

solve(["500",
    "Bellini",
    "6",
    "Bamboo",
    "7",
    "Party!"]);
