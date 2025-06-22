function solve([tournamentsCount, initialPoints, ...results]) {
    tournamentsCount = Number(tournamentsCount);
    initialPoints = Number(initialPoints);
    let totalPoints = 0;
    let wins = 0;

    for (let index = 0; index < tournamentsCount; index++) {
        let currentResult = results[index];

        if (currentResult === 'W') {
            totalPoints += 2000;
            wins++;
        } else if (currentResult === 'F') {
            totalPoints += 1200;
        } else {
            totalPoints += 720;
        }
    }

    let finalPoints = initialPoints + totalPoints;
    let averagePoints = totalPoints / tournamentsCount;
    let percentWins = wins / tournamentsCount * 100;

    console.log(`Final points: ${finalPoints}`);
    console.log(`Average points: ${Math.floor(averagePoints)}`);
    console.log(`${percentWins.toFixed(2)}%`)
}

solve(["5",
    "1400",
    "F",
    "SF",
    "W",
    "W",
    "SF"]);
