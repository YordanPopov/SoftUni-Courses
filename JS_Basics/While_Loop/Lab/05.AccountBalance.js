function solve([...input]) {
    let totalBalance = 0;
    let index = 0;
    let currentInput = input[index];

    while (currentInput !== "NoMoreMoney") {
        if (Number(currentInput) < 0) {
            console.log("Invalid operation!");
            break;
        } else {
            console.log(`Increase: ${Number(currentInput).toFixed(2)}`);
            totalBalance += Number(currentInput);
        }
        
        index++;
        currentInput = input[index];
    }

    console.log(`Total: ${totalBalance.toFixed(2)}`);
}

solve(["5.51",
    "69.42",
    "100",
    "NoMoreMoney"]);