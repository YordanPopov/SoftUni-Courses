function solve(days, foodLeft, dogFoodPerDay, catFoodPerDay, turtleFoodPerDayInGrams) {
    let turtleFoodPerDayInKg = turtleFoodPerDayInGrams / 1000;
    let totalNeedFood = days * (dogFoodPerDay + catFoodPerDay + turtleFoodPerDayInKg);

    if (foodLeft >= totalNeedFood) {
        console.log(`${Math.floor(foodLeft - totalNeedFood)} kilos of food left.`);
    } else {
        console.log(`${Math.ceil(totalNeedFood - foodLeft)} more kilos of food are needed.`);
    }
}

solve(5, 10, 2.1, 0.8, 321);