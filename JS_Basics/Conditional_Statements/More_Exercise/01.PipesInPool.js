function solve(poolVolume, firstPipeDebit, secondPipeDebit, missingHours) {
    let waterFromFirstPipe = missingHours * firstPipeDebit;
    let waterFromSecondPipe = missingHours * secondPipeDebit;
    let totalWater = waterFromFirstPipe + waterFromSecondPipe;

    if (totalWater <= poolVolume) {
        let percentageFull = (totalWater / poolVolume) * 100;
        let firstPipeContribution = (waterFromFirstPipe / totalWater) * 100;
        let secondPipeContribution = (waterFromSecondPipe / totalWater) * 100;

        console.log(`The pool is ${percentageFull.toFixed(2)}% full. Pipe 1: ${firstPipeContribution.toFixed(2)}%. Pipe 2: ${secondPipeContribution.toFixed(2)}%.`);
    } else {
        let overflow = totalWater - poolVolume;

        console.log(`For ${missingHours.toFixed(2)} hours the pool overflows with ${overflow.toFixed(2)} liters.`);
    }
}

solve(100, 100, 100, 2.5);