function printNeededMoney(arr) {
    let fruit = arr[0];
    let grams = arr[1];
    let priceKg = arr[2];
  let kg = grams / 1000.0;
  let neededMoney = priceKg * kg;
  console.log(`I need $${neededMoney.toFixed(2)} to buy ${kg.toFixed(2)} kilograms ${fruit}.`);
}

printNeededMoney(['orange', 2500, 1.80]);
printNeededMoney(['apple', 1563, 2.35]);