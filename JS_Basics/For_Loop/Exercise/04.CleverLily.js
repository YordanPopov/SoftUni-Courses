function solve(age, washingMachinePrice, toyPrice) {
    let totalMoney = 0;
    let toysCount = 0;

    for (let i = 1; i <= age; i++) {
        if (i % 2 === 0) {
            totalMoney += (i / 2) * 10 - 1;
        } else {
            toysCount++;
        }
    }

    totalMoney += toysCount * toyPrice;

    if (totalMoney >= washingMachinePrice) {
        console.log(`Yes! ${(totalMoney - washingMachinePrice).toFixed(2)}`);
    } else {
        console.log(`No! ${(washingMachinePrice - totalMoney).toFixed(2)}`);
    }
    
}

solve(21, 1570.98, 3);