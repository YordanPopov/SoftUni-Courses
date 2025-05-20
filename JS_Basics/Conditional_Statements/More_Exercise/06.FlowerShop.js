function solve(magnoliaCount, hyacinthCount, roseCount, cactusCount, giftPrice) {
    let totalAmount = magnoliaCount * 3.25 + hyacinthCount * 4 + roseCount * 3.50 + cactusCount * 8;
    let remainingAmount = totalAmount * 0.95;

    if (remainingAmount >= giftPrice) {
        console.log(`She is left with ${Math.floor(remainingAmount - giftPrice)} leva.`);
    } else {
        console.log(`She will have to borrow ${Math.ceil(giftPrice - remainingAmount)} leva.`);
    }
}

solve(15, 7, 5, 10, 100);