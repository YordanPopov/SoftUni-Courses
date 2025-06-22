function solve([playerName, ...input]) {
    let index = 0;
    let initialPoints = 301;
    let isWon = false;
    let successfulShots = 0;
    let unsuccessfulShots = 0;

    while (input[index] != 'Retire') {
        let field = input[index++];
        let points = Number(input[index++]);
        let currentPoints = 0;

        switch (field) {
            case 'Single': currentPoints += points; break;
            case 'Double': currentPoints += 2 * points; break;
            case 'Triple': currentPoints += 3 * points; break;
        }

        if (currentPoints <= initialPoints) {
            successfulShots++;
            initialPoints -= currentPoints;
        } else {
            unsuccessfulShots++;
        }

        if (initialPoints === 0) {
            isWon = true;
            break;
        }
    }

    if (isWon) {
        console.log(`${playerName} won the leg with ${successfulShots} shots.`)
    } else {
        console.log(`${playerName} retired after ${unsuccessfulShots} unsuccessful shots.`)
    }
}

solve(["Rob Cross",
    "Triple",
    "20",
    "Triple",
    "20",
    "Triple",
    "20",
    "Triple",
    "20",
    "Double",
    "20",
    "Triple",
    "20",
    "Double",
    "5",
    "Triple",
    "10",
    "Double",
    "6",
    "Retire"])

