function solve([vacationCost, initialSavings, ...actions]) {
    vacationCost = Number(vacationCost);
    initialSavings = Number(initialSavings);

    let index = 0;
    let currentAction = actions[index];
    let totalSavings = initialSavings;
    let daysCount = 0;
    let spendDaysCount = 0;

    while (true) {
        if (currentAction === 'spend') {
            spendDaysCount++;
            daysCount++;

            if (spendDaysCount === 5) {
                console.log(`You can't save the money.\n${daysCount}`);
                break;
            }

            let amountSpent = Number(actions[index + 1]);
            if (amountSpent > totalSavings) {
                totalSavings = 0;
            } else {
                totalSavings -= amountSpent;
            }
        } else if (currentAction === 'save') {
            let amountSaved = Number(actions[index + 1]);
            totalSavings += amountSaved;
            spendDaysCount = 0;
            daysCount++;
        }

        if (totalSavings >= vacationCost) {
            console.log(`You saved the money for ${daysCount} days.`);
            break;
        }

        index += 2;
        currentAction = actions[index];
    }
}

solve(["110",
    "60",
    "spend",
    "10",
    "spend",
    "10",
    "spend",
    "10",
    "spend",
    "10",
    "save",
    "10",
    "spend",
    "10"]);

