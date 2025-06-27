function solve([budget, ...input]) {
    budget = Number(budget);
    let originalBudget = budget;
    let totalSpentMoney = 0;

    let index = 0;
    while (input[index] !== 'ACTION') {
        let actorName = input[index++];
        let reward = 0;

        if (actorName.length <= 15) {
            reward = Number(input[index++]);
        } else {
            reward = budget * 0.2;
        }

        if (reward > budget) {
            let neededMoney = totalSpentMoney + reward - originalBudget;
            console.log(`We need ${neededMoney.toFixed(2)} leva for our actors.`);
            return;
        }

        budget -= reward;
        totalSpentMoney += reward;
    }

    console.log(`We are left with ${budget.toFixed(2)} leva.`);
}

solve(["170000",
    "Ben Affleck",
    "40000.50",
    "Zahari Baharov",
    "80000",
    "Tom Hanks",
    "2000.99",
    "ACTION"]);


