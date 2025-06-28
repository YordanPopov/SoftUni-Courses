function solve(fatPercent, proteinPercent, carbPercent, totalCalories, waterPercent) {
    let fatGrams = (fatPercent / 100) * totalCalories / 9;
    let proteinGrams = (proteinPercent / 100) * totalCalories / 4;
    let carbGrams = (carbPercent / 100) * totalCalories / 4;

    let totalFoodWeight = fatGrams + proteinGrams + carbGrams;
    let caloriesPerGram = totalCalories / totalFoodWeight;
    let totalCalculatedCalories = (1 - (waterPercent / 100)) * caloriesPerGram;

    console.log(totalCalculatedCalories.toFixed(4));
}

solve(40, 40, 20, 3000, 40);