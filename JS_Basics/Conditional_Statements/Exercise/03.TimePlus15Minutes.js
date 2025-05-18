function solve(hour, minutes){
    minutes += 15;

    if (minutes > 59) {
        hour++;
        minutes -= 60;
    }

    if (hour > 23) {
        hour -= 24;
    }

    if (minutes < 10) {
        console.log(`${hour}:0${minutes}`);
    } else {
        console.log(`${hour}:${minutes}`);
    }
}

solve(12, 49);