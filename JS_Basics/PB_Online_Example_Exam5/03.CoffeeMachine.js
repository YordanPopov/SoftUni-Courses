function solve(drink, sugar, drinksCount) {
    const prices = {
        Espresso: {
            Without: { price: 0.90 },
            Normal: { price: 1.00 },
            Extra: { price: 1.20 }
        },
        Cappuccino: {
            Without: { price: 1.00 },
            Normal: { price: 1.20 },
            Extra: { price: 1.60 }
        },
        Tea: {
            Without: { price: 0.50 },
            Normal: { price: 0.60 },
            Extra: { price: 0.70 }
        }
    }

    let { price } = prices[drink][sugar];
    let totalPrice = price * drinksCount;

    if (sugar === 'Without') {
        totalPrice *= 0.65;
    }
    if (drink === 'Espresso' && drinksCount >= 5) {
        totalPrice *= 0.75;
    }
    if (totalPrice > 15) {
        totalPrice *= 0.8;
    }

    console.log(`You bought ${drinksCount} cups of ${drink} for ${totalPrice.toFixed(2)} lv.`)
}

solve('Cappuccino', 'Normal', 13);