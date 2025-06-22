function solve([targetHeigth, ...jumpAtempts]) {
    targetHeigth = Number(targetHeigth);
    jumpAtempts = jumpAtempts.map(Number);
    let currentBarHeight = targetHeigth - 30;
    let totalJumpsFromBegining = 0;
    let failedAttemptsAtCurrentHeight = 0;
    let lastSuccessfulHeight = currentBarHeight;

    for (const currentJumpAtempt of jumpAtempts) {
        if (currentJumpAtempt > currentBarHeight) {
            if (failedAttemptsAtCurrentHeight !== 0) {
                failedAttemptsAtCurrentHeight = 0;
            }
          
            totalJumpsFromBegining++;
            lastSuccessfulHeight = currentBarHeight;
            if (currentBarHeight >= targetHeigth) {
                console.log(`Tihomir succeeded, he jumped over ${lastSuccessfulHeight}cm after ${totalJumpsFromBegining} jumps.`)
            }

            currentBarHeight += 5;
        } else {
            totalJumpsFromBegining++;
            failedAttemptsAtCurrentHeight++;

            if (failedAttemptsAtCurrentHeight === 3) {
                console.log(`Tihomir failed at ${currentBarHeight}cm after ${totalJumpsFromBegining} jumps.`)
            }
        }
    }
}

solve(["250",
    "225",
    "224",
    "225",
    "228",
    "231",
    "235",
    "234",
    "235"]);

