let stopWatchInterval;
let elapsedTime = 0;
let savedTimeInterval;

function startStopWatch() {
    console.log("StopWatch started!");
    stopWatchInterval = setInterval(() => {
        elapsedTime++;
        console.log("Elapsed time: " + elapsedTime + "s");
    }, 1000);

    savedTimeInterval = setInterval(async () => {
        await saveElapsedTime(elapsedTime);
    }, 5000);
}

function stopStopWatch() {
    clearInterval(stopWatchInterval);
    clearInterval(savedTimeInterval);
    stopWatchInterval = null;
    savedTimeInterval = null;
    elapsedTime = 0;
    console.log("Watch stoped!");

}

function saveElapsedTime(time) {
    return new Promise((resolve, reject) => {
        setTimeout(() => {
            console.log("Elapsed time saved: " + time);
            resolve();
        }, 500);
    });
}