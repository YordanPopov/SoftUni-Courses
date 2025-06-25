function solve([customers, ...input]) {
    customers = Number(customers);
    let index = 0;
    let totalSpentMoney = 0;
    const prices = {
        'basket': 1.50,
        'wreath': 3.80,
        'chocolate bunny': 7.00
    }

    for (let i = 0; i < customers; i++) {
        let currentInput = input[index];
        let purchaseCount = 0;
        let spentMoney = 0;

        while (true) {
            let purchase = input[index++];

            if (purchase === 'Finish') {
                break;
            } else if (purchase === 'basket') {
                spentMoney += prices[purchase];
            } else if (purchase === 'wreath') {
                spentMoney += prices[purchase];
            } else if (purchase === 'chocolate bunny') {
                spentMoney += prices[purchase];
            }

            purchaseCount++;
        }

        if (purchaseCount % 2 === 0) {
            spentMoney *= 0.8;
        }

        totalSpentMoney += spentMoney;
        console.log(`You purchased ${purchaseCount} items for ${spentMoney.toFixed(2)} leva.`)
    }

    console.log(`Average bill per client is: ${(totalSpentMoney / customers).toFixed(2)} leva.`)
}

solve(["1",
    "basket",
    "wreath",
    "chocolate bunny",
    "wreath",
    "basket",
    "chocolate bunny",
    "Finish"])

