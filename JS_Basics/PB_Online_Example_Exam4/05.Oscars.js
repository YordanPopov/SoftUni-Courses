function solve([actorName, pointsFromAcademy, juryCount, ...input]) {
    let initialPoints = Number(pointsFromAcademy);
    let totalPoints = initialPoints;

    let index = 0;
    for (let i = 0; i < Number(juryCount); i++) {
        let judgeName = input[index++];
        let judgePoints = Number(input[index++]);
        let currentPoints = judgeName.length * judgePoints / 2;

        totalPoints += currentPoints;

        if (totalPoints > 1250.5) {
            console.log(`Congratulations, ${actorName} got a nominee for leading role with ${totalPoints.toFixed(1)}!`);
            return;
        }
    }

    let neededPoints = 1250.5 - totalPoints;
    console.log(`Sorry, ${actorName} you need ${neededPoints.toFixed(1)} more!`)
}

solve(["Zahari Baharov",
    "205",
    "4",
    "Johnny Depp",
    "45",
    "Will Smith",
    "29",
    "Jet Lee",
    "10",
    "Matthew Mcconaughey",
    "39"]);
