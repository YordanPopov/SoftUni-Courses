function solve(examHour, examMinute, arrivalHour, arrivalMinute) {
    const examTime = examHour * 60 + examMinute;
    const arrivalTime = arrivalHour * 60 + arrivalMinute;
    const diff = arrivalTime - examTime;
    const absDiff = Math.abs(diff);

    function formatTime(minutes) {
        const h = Math.floor(minutes / 60);
        const m = minutes % 60;
        return h > 0
            ? `${h}:${m < 10 ? '0' + m : m} hours`
            : `${m} minutes`;
    }

    if (diff > 0) {
        console.log(`Late`);
        console.log(`${formatTime(diff)} after the start`);
    } else if (diff >= -30) {
        console.log(`On time`);
        if(diff !== 0){
            console.log(`${formatTime(absDiff)} before the start`);
        }
    } else {
        console.log(`Early`);
        console.log(`${formatTime(absDiff)} before the start`);
    }
}

solve(9, 30, 9, 50);
solve(9, 0, 8, 30);
solve(16, 0, 15, 0);
solve(9, 0, 10, 30);
solve(14, 0, 13, 55);
solve(11, 30, 8, 12);
solve(10, 0, 10, 0);
solve(11, 30, 10, 55);
solve(11, 30, 12, 29);