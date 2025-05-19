function solve(recordInSec, destinationInMeters, timeForOneMeterInSec) {
    let totalTimeInSec = destinationInMeters * timeForOneMeterInSec;
    let delay = Math.floor(destinationInMeters / 15) * 12.5;

    totalTimeInSec += delay;

    if (totalTimeInSec < recordInSec) {
        console.log(`Yes, he succeeded! The new world record is ${totalTimeInSec.toFixed(2)} seconds.`);
    } else {
        console.log(`No, he failed! He was ${Math.abs(recordInSec - totalTimeInSec).toFixed(2)} seconds slower.`);
    }
}

solve(55555.67, 3017, 5.03);