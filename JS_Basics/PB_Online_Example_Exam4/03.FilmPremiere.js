function solve(projection, moviePacket, ticketsCount) {
    const prices = {
        'John Wick': { Drink: 12, Popcorn: 15, Menu: 19 },
        'Star Wars': { Drink: 18, Popcorn: 25, Menu: 30 },
        'Jumanji': { Drink: 9, Popcorn: 11, Menu: 14 }
    }

    let totalPrice = prices[projection][moviePacket] * ticketsCount;

    if (projection === 'Star Wars' && ticketsCount >= 4) {
        totalPrice *= 0.7;
    } else if (projection === 'Jumanji' && ticketsCount === 2) {
        totalPrice *= 0.85;
    }

    console.log(`Your bill is ${totalPrice.toFixed(2)} leva.`)
}

solve('Star Wars', 'Popcorn', 4);