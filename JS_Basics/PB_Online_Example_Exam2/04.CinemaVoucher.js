function solve([voucherCost, ...purchases]) {
    voucherCost = Number(voucherCost);
    let index = 0;
    let ticketsCount = 0;
    let otherPurchases = 0;

    while (purchases[index] !== 'End') {
        let purchase = purchases[index++];
        let purchasePrice = 0;

        if (purchase.length > 8) {
            let firstCharCode = purchase.charCodeAt(0);
            let secondCharCode = purchase.charCodeAt(1);

            purchasePrice += firstCharCode + secondCharCode;
            if (purchasePrice > voucherCost) {
                break;
            } else {
                ticketsCount++;
                voucherCost -= purchasePrice;
            }
        } else {
            let firstCharCode = purchase.charCodeAt(0);

            purchasePrice += firstCharCode;
            if (purchasePrice > voucherCost) {
                break;
            } else {
                otherPurchases++;
                voucherCost -= purchasePrice;
            }
        }
    }

    console.log(`${ticketsCount}\n${otherPurchases}`);
}

solve(["1500",
    "Avengers: Endgame",
    "Bohemian Rhapsody",
    "Deadpool 2",
    "End"]);

