function solve([targetAmount, ...input]) {
    let currentAmount = 0;
    let cashPayments = 0;
    let cardPayments = 0;
    let cashTransactionCount = 0;
    let cardTransactionCount = 0;
    let isEnough = false;

    let index = 0;
    let currentInput = input[index];

    while (currentInput !== 'End') {
        let price = Number(currentInput);
        if ((index + 1) % 2 !== 0) {
            if (price > 100) {
                console.log(`Error in transaction!`);
            } else {
                currentAmount += price;
                cashPayments += price;
                cashTransactionCount++;
                console.log(`Product sold!`);
            }
        } else {
            if (price < 10) {
                console.log(`Error in transaction!`);
            } else {
                currentAmount += price;
                cardPayments += price;
                cardTransactionCount++;
                console.log(`Product sold!`)
            }
        }

        if (currentAmount >= targetAmount) {
            console.log(`Average CS: ${(cashPayments / cashTransactionCount).toFixed(2)}`);
            console.log(`Average CC: ${(cardPayments / cardTransactionCount).toFixed(2)}`);
            isEnough = true;
            break;
        }

        index++;
        if (index >= input.length) {
            break;
        } else {
            currentInput = input[index];
        }
    }

    if (!isEnough) {
        console.log(`Failed to collect required money for charity.`);
    }
}

solve(["600",
    "86",
    "150",
    "98",
    "227",
    "End"]);

