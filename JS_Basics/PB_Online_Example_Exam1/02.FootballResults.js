function solve(firstResult, secondResult, thirdResult) {
    let wins = 0;
    let losses = 0;
    let equalities = 0;

    let results = [firstResult, secondResult, thirdResult];
    for (const result of results) {
        if (result[0] > result[result.length - 1]) {
            wins++;
        } else if (result[0] < result[result.length - 1]) {
            losses++;
        } else {
            equalities++;
        }
    }

    console.log(`Team won ${wins} games.`);
    console.log(`Team lost ${losses} games.`);
    console.log(`Drawn games: ${equalities}`);
}

solve('3:1', '0:2', '0:0');