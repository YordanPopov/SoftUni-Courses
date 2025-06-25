function solve(numOfPashas, numOfEggBoxes, numOfCookies) {
    const prices = {
        'pushas': 3.20,
        'eggs': 4.35,
        'cookies': 5.40,
        'dye': 0.15
    }

    const totalCost = (numOfPashas * prices['pushas']) + (numOfEggBoxes * prices['eggs'])
        + (numOfCookies * prices['cookies']) + (numOfEggBoxes * 12 * prices['dye']);

    console.log(totalCost.toFixed(2));
}

solve(4, 4, 3);