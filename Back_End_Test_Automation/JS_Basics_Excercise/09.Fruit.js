function printNeededMoney(inputArr) {
  let fruit = inputArr[0];
  let weight = inputArr[1] / 1000;
  let pricePerKg = inputArr[2];

  let output = `I need $${(weight * pricePerKg).toFixed(2)} to buy ${weight.toFixed(2)} kilograms ${fruit}.`;

  console.log(output);
}

printNeededMoney(['orange', 2500, 1.80]);
printNeededMoney(['apple', 1563, 2.35]);