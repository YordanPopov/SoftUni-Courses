function solve(input) {
    let index = 0;
    let currentInput = input[index];
    let goal = 10_000;
    let stepsToGoal = 0;
    let isWalkToHome = false;

    while (true) {
        if (currentInput === 'Going home') {
            index++;
            let stepsToHome = Number(input[index]);

            stepsToGoal += stepsToHome;
            isWalkToHome = true;
        } else {
            let steps = Number(input[index]);
            stepsToGoal += steps;
        }

        if (stepsToGoal >= goal) {
            console.log(`Goal reached! Good job!\n${stepsToGoal - goal} steps over the goal!`);
            break;
        } else if (isWalkToHome) {
            console.log(`${goal - stepsToGoal} more steps to reach goal.`);
            break;
        }

        index++;
        currentInput = input[index];
    }
}

solve(["1500",
    "3000",
    "250",
    "1548",
    "2000",
    "Going home",
    "2000"])



