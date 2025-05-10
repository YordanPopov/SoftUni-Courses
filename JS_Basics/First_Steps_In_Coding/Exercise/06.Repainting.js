function calculateExpense(nylonNeeded, paintNeeded, thinnerNeeded, workHours) {
    let nylonPricePerSqm = 1.50;
    let paintPiricePerSqm = 14.50;
    let thinnerPricePerLiter = 5.00;
    let bagPrice = 0.40;
    let extraNylon = 2;

    let nylonCost = (nylonNeeded + extraNylon) * nylonPricePerSqm;
    let paintCost = ((paintNeeded * 0.1) + paintNeeded) * paintPiricePerSqm;
    let thinnerCost = thinnerNeeded * thinnerPricePerLiter;
    let totalMaterialCost = nylonCost + paintCost + thinnerCost + bagPrice;
    let laborCostPerHour = totalMaterialCost * 0.3;
    let totalLaborCost = laborCostPerHour * workHours;
    let totalCost = totalLaborCost + totalMaterialCost;

    console.log(totalCost);
}

calculateExpense(10, 11, 4, 8);
calculateExpense(5, 10, 10, 1);