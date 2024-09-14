function printNeededMoney(fruit, grams, priceKg) {
    let kg = grams / 1000;
    let neededMoney = priceKg * kg;
    console.log(`I need $${neededMoney.toFixed(2)} to buy ${kg.toFixed(2)} kilograms ${fruit}.`);
}

printNeededMoney('orange', 2500, 1.80);
printNeededMoney('apple', 1563, 2.35);