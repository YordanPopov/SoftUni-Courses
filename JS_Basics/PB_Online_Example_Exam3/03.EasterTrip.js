function solve(destination, date, nights) {
    const prices = {
        France: {
            '21-23': 30.0,
            '24-27': 35.0,
            '28-31': 40.0
        },
        Italy: {
            '21-23': 28.0,
            '24-27': 32.0,
            '28-31': 39.0
        },
        Germany: {
            '21-23': 32.0,
            '24-27': 37.0,
            '28-31': 43.0
        }
    }

    const price = prices[destination][date];
    const totalCost = price * nights;

    console.log(`Easter trip to ${destination} : ${totalCost.toFixed(2)} leva.`);
}

solve('Germany', '24-27', 5);