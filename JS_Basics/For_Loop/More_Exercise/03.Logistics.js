function solve([numberOfLoads, ...weights]) {
    numberOfLoads = Number(numberOfLoads);
    weights = weights.map(Number);

    let totalWeight = 0;
    let totalCost = 0;
    const loads = [0, 0, 0]; // [bus, truck, train]

    for (const weight of weights) {
        totalWeight += weight;

        if (weight <= 3) {
            totalCost += weight * 200;
            loads[0] += weight;
        } else if (weight <= 11) {
            totalCost += weight * 175;
            loads[1] += weight;
        } else {
            totalCost += weight * 120;
            loads[2] += weight;
        }
    }

    console.log(`${(totalCost / totalWeight).toFixed(2)}`);
    loads.forEach(load => console.log(`${(load / totalWeight * 100).toFixed(2)}%`));
}

solve(['5', '2', '10', '20', '1', '7']);