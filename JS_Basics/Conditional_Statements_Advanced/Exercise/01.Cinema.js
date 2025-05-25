function solve(projection, rows, columns) {
    const ticketPrice = {
        "Premiere": 12.00,
        "Normal": 7.50,
        "Discount": 5.00
    };

    let totalIncome = rows * columns * ticketPrice[projection];
    console.log(`${(totalIncome).toFixed(2)} leva`);
}

solve('Normal', 21, 13);