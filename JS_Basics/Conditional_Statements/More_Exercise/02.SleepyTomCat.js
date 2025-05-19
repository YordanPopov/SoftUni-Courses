function solve(daysOff) {
    let workingDays = 365 - daysOff;
    let playTimeWeekDays = 63;
    let playTimeWeekends = 127;
    let totalPlayTime = (daysOff * playTimeWeekends) + (workingDays * playTimeWeekDays);
    let normalPlayTime = 30000;
    let difference;
    let hours;
    let minutes

    if (normalPlayTime > totalPlayTime) {
        difference = normalPlayTime - totalPlayTime;
        hours = Math.trunc(difference / 60);
        minutes = difference % 60;

        console.log(`Tom sleeps well\n${hours} hours and ${minutes} minutes less for play`);
    } else {
        difference = totalPlayTime - normalPlayTime;
        hours = Math.trunc(difference / 60);
        minutes = difference % 60;

        console.log(`Tom will run away\n${hours} hours and ${minutes} minutes more for play`);
    }
}

solve(113);