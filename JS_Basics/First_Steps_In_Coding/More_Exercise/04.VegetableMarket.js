function calcPrice(vegetablesPricePerKg, fruitsPricePerKg, totalKgVegetables, totalKgFruits) {
    let totalCost = (vegetablesPricePerKg * totalKgVegetables) + (fruitsPricePerKg * totalKgFruits);
    let costInEur = totalCost / 1.94;

    console.log(costInEur.toFixed(2)); 
}

calcPrice(0.194, 19.4, 10, 10);
calcPrice(1.5, 2.5, 10, 10);