function calculatePriceForFood(dogFoodCount, catFoodCount) {
    let dogFoodPrice = 2.50;
    let catFoodPrice = 4;

    let totalPrice = (dogFoodCount * dogFoodPrice) + (catFoodCount * catFoodPrice);
    let output = `${totalPrice} lv.`;

    console.log(output);
}

calculatePriceForFood(5, 4);
calculatePriceForFood(13, 9);
