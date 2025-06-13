function solve([freeSpaceWidth, freeSpaceLength, freeSpaceHeight, ...cartons]) {
    let totalVolume = Number(freeSpaceHeight * freeSpaceLength * freeSpaceWidth);

    let index = 0;
    let currentCommand = cartons[index];

    while (currentCommand !== 'Done') {
        let cartonsCount = Number(currentCommand);

        if (cartonsCount > totalVolume) {
            totalVolume -= cartonsCount;
            console.log(`No more free space! You need ${Math.abs(totalVolume)} Cubic meters more.`);
            break;
        } else {
            totalVolume -= cartonsCount;
        }

        index++;
        currentCommand = cartons[index];
    }

    if (totalVolume >= 0) {
        console.log(`${totalVolume} Cubic meters left.`);
    }
}

solve(["10",
    "1",
    "2",
    "4",
    "6",
    "Done"])

