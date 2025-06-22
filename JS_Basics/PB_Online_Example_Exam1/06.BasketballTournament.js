function solve(input) {
    let index = 0;
    let wins = 0;
    let losses = 0;
    let totalMatches = 0;

    while (input[index] !== 'End of tournaments') {
        let tournamentName = input[index++];
        let matchCount = Number(input[index++]);

        for (let match = 1; match <= matchCount; match++) {
            let desiTeamPoints = Number(input[index++]);
            let otherTeamPoints = Number(input[index++]);

            if (desiTeamPoints > otherTeamPoints) {
                wins++;
                console.log(`Game ${match} of tournament ${tournamentName}: win with ${desiTeamPoints - otherTeamPoints} points.`)
            } else {
                losses++;
                console.log(`Game ${match} of tournament ${tournamentName}: lost with ${otherTeamPoints - desiTeamPoints} points.`)
            }
        }
    }

    totalMatches = wins + losses;
    console.log(`${(wins / totalMatches * 100).toFixed(2)}% matches win`);
    console.log(`${(losses / totalMatches * 100).toFixed(2)}% matches lost`)
}

solve(["Dunkers",
    "2",
    "75",
    "65",
    "56",
    "73",
    "Fire Girls",
    "3",
    "67",
    "34",
    "83",
    "98",
    "66",
    "45",
    "End of tournaments"]);
