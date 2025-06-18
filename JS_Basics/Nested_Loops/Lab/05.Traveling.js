function solve(input) {
    let index = 0;

    while (input[index] !== 'End') {
        let destination = input[index++];
        let budget = Number(input[index++]);
        let savedMoney = 0;

        while (savedMoney < budget) {
            let amount = Number(input[index++]);
            savedMoney += amount;
        }

        console.log(`Going to ${destination}!`);
    }
}

solve(["Greece",
    "1000",
    "200",
    "200",
    "300",
    "100",
    "150",
    "240",
    "Spain",
    "1200",
    "300",
    "500",
    "193",
    "423",
    "End"]);
