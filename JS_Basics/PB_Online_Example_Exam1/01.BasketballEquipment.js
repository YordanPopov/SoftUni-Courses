function calculateExpense(annualTrainingFee) {
    let shoesPrice = annualTrainingFee - (annualTrainingFee * 0.4);
    let outfitPrice = shoesPrice - (shoesPrice * 0.2);
    let ballPrice = outfitPrice * 0.25;
    let accessoriesPrice = ballPrice * 0.2;

    let totalCost = shoesPrice + outfitPrice + ballPrice + accessoriesPrice + annualTrainingFee;
    console.log(totalCost.toFixed(2));
}

calculateExpense(320);
calculateExpense(550);