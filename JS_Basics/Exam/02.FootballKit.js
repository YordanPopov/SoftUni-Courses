function solve(tshirtPrice, neededSum) {
    let shorts = tshirtPrice * 0.75;
    let socks = shorts * 0.20;
    let shoes = (tshirtPrice + shorts) * 2.00;

    let totalCost = tshirtPrice + shorts + socks + shoes;
    let finalCost = totalCost * 0.85;

    if (finalCost >= neededSum) {
        console.log(`Yes, he will earn the world-cup replica ball!`);
        console.log(`His sum is ${finalCost.toFixed(2)} lv.`);
    } else {
        console.log(`No, he will not earn the world-cup replica ball.`);
        console.log(`He needs ${(neededSum - finalCost).toFixed(2)} lv. more.`);
    }
}

solve(55, 310);