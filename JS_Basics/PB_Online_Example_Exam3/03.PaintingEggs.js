function solve(eggsSize, eggsColor, batchCount) {
    const prices = {
        Large: { Red: 16, Green: 12, Yellow: 9 },
        Medium: { Red: 13, Green: 9, Yellow: 7 },
        Small: { Red: 9, Green: 8, Yellow: 5 }
    }

    const batchPrice = prices[eggsSize][eggsColor] * batchCount;
    const totalExpense = batchPrice - (batchPrice * 0.35);
    console.log(`${totalExpense.toFixed(2)} leva.`)
}

solve('Large', 'Red', 7);