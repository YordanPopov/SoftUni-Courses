function solve([tournamentCount, startingPoints, ...results]) {
    let points = Number(startingPoints);
    let tournamentsWon = 0;

    for (let result of results) {
        switch (result) {
            case "W":
                points += 2000;
                tournamentsWon++;
                break;
            case "F":
                points += 1200;
                break;
            case "SF":
                points += 720;
                break;
        }
    }

    console.log(`Final points: ${points}`);
    console.log(`Average points: ${Math.floor((points - Number(startingPoints)) / tournamentCount)}`);
    console.log(`${((tournamentsWon / tournamentCount) * 100).toFixed(2)}%`);
}

solve(["5",
    "1400",
    "F",
    "SF",
    "W",
    "W",
    "SF"]);
