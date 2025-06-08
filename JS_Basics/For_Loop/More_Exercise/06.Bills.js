function solve([months, ...electricityBill]) {
    months = Number(months);
    electricityBill = electricityBill.map(Number);

    let total = 0;
    let bills = {
        "Electricity": 0,
        "Water": 0,
        "Internet": 0,
        "Other": 0, 
    }

    for (let i = 0; i < months; i++) {
        let currentBill = electricityBill[i];
        bills["Electricity"] += currentBill;
        bills["Water"] += 20;
        bills["Internet"] += 15;
        bills["Other"] += (currentBill + 20 + 15) * 1.2;

        total += currentBill + 20 + 15 + ((currentBill + 20 + 15) * 1.2);
    }

    bills["Average"] = total / months;

    for (const bill in bills) {
        console.log(`${bill}: ${bills[bill].toFixed(2)} lv`);
    }
}

solve(["5",
    "68.63",
    "89.25",
    "132.53",
    "93.53",
    "63.22"]);
