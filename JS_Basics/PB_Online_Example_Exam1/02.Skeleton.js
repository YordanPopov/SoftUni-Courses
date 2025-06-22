function solve(controlToBeReachedInMinutes, controlSeconds, length, secondsPer100Meters) {
    let controlToBeReachedInSeconds = controlToBeReachedInMinutes * 60 + controlSeconds;
    let delay = length / 120;
    let delayTime = delay * 2.5;
    let time = (length / 100) * secondsPer100Meters - delayTime;

    if (time <= controlToBeReachedInSeconds) {
        console.log(`Marin Bangiev won an Olympic quota!`);
        console.log(`His time is ${time.toFixed(3)}.`);
    } else {
        console.log(`No, Marin failed! He was ${(time - controlToBeReachedInSeconds).toFixed(3)} second slower.`);
    }
}

solve(1, 20, 1546, 12);