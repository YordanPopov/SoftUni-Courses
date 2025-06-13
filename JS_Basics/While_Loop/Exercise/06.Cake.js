function solve([cakeWidth, cakeLength, ...commands]) {
    let totalPieces = Number(cakeWidth) * Number(cakeLength);

    let index = 0;
    let currentCommand = commands[index];

    while (currentCommand !== 'STOP') {
        let takenPieces = Number(currentCommand);

        if (takenPieces > totalPieces) {
            totalPieces -= takenPieces;
            console.log(`No more cake left! You need ${Math.abs(totalPieces)} pieces more.`);
            break;
        } else {
            totalPieces -= takenPieces;
        }

        index++;
        currentCommand = commands[index];
    }

    if (totalPieces >= 0) {
        console.log(`${totalPieces} pieces are left.`)
    }
}

solve(["10",
    "10",
    "20",
    "20",
    "20",
    "20",
    "21"]);

