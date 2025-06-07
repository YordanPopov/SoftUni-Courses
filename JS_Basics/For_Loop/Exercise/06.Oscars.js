function solve([actorName, actorPoints, juryCount, ...juryVotes]) {
    let totalPoints = Number(actorPoints);

    for (let i = 0; i < juryCount; i++) {
        let juryName = juryVotes[i * 2];
        let juryPoints = Number(juryVotes[i * 2 + 1]);

        totalPoints += juryName.length * juryPoints / 2;

        if (totalPoints >= 1250.5) {
            console.log(`Congratulations, ${actorName} got a nominee for leading role with ${totalPoints.toFixed(1)}!`);
            return;
        }
    }

    if (totalPoints < 1250.5) {
        console.log(`Sorry, ${actorName} you need ${(1250.5 - totalPoints).toFixed(1)} more!`);
    }
}

solve(["Zahari Baharov",
    "205",
    4,
    "Johnny Depp",
    "45",
    "Will Smith",
    "29",
    "Jet Lee",
    "10",
    "Matthew Mcconaughey",
    "39"]);
