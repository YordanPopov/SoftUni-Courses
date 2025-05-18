function solve(seriasName, episodeDuration, breakDuration) {
    let lunchTime = breakDuration * (1 / 8);
    let restTime = breakDuration * (1 / 4);

    let totalTime = breakDuration - (lunchTime + restTime);

    if (totalTime >= episodeDuration) {
        console.log(`You have enough time to watch ${seriasName} and left with ${Math.ceil(totalTime - episodeDuration)} minutes free time.`);
    } else {
        console.log(`You don't have enough time to watch ${seriasName}, you need ${Math.ceil(episodeDuration - totalTime)} more minutes.`);
    }
}

solve('Game of Thrones', 48, 60);     