function solve([easterBreadCount, ...input]) {
    easterBreadCount = Number(easterBreadCount);
    let maxFlour = 0;
    let totalFlour = 0;
    let maxSugar = 0;
    let totalSugar = 0;
    let index = 0;

    for (let i = 0; i < easterBreadCount; i++) {
        let sugarSpent = Number(input[index++]);
        let flourSPent = Number(input[index++]);

        totalFlour += flourSPent;
        totalSugar += sugarSpent;

        if (sugarSpent > maxSugar) {
            maxSugar = sugarSpent;
        }

        if (flourSPent > maxFlour) {
            maxFlour = flourSPent;
        }
    }

    let sugarPackets = Math.ceil(totalSugar / 950);
    let flourPackets = Math.ceil(totalFlour / 750);

    console.log(`Sugar: ${sugarPackets}`);
    console.log(`Flour: ${flourPackets}`);
    console.log(`Max used flour is ${maxFlour} grams, max used sugar is ${maxSugar} grams.`)
}

solve(["3",
    "400",
    "350",
    "250",
    "300",
    "450",
    "380"]);
