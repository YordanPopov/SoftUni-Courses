function solve(flourPriceKg, flourKg, sugarKg, boxOfEggs, yeastPackets) {
    let sugarPriceKg = flourPriceKg * 0.75;
    let boxOfEggsPrice = flourPriceKg * 1.1;
    let yeastPrice = sugarPriceKg * 0.2;

    let totalCost = (flourPriceKg * flourKg) + (sugarPriceKg * sugarKg) + (boxOfEggsPrice * boxOfEggs) + (yeastPackets * yeastPrice);
    console.log(totalCost.toFixed(2));
}

solve(50, 10, 3.5, 6, 1);