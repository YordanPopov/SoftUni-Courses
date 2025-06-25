function solve(numberOfGuests, budget) {
    const prices = {
        'easter bread': 4.0,
        'egg': 0.45
    }

    let neededEasterBread = Math.ceil(numberOfGuests / 3);
    let neededEggs = numberOfGuests * 2;
    let totalCost = (neededEasterBread * prices['easter bread']) + (neededEggs * prices['egg']);

    if (budget >= totalCost) {
        console.log(`Lyubo bought ${neededEasterBread} Easter bread and ${neededEggs} eggs.`);
        console.log(`He has ${(budget - totalCost).toFixed(2)} lv. left.`);
    } else {
        console.log(`Lyubo doesn't have enough money.\nHe needs ${(totalCost - budget).toFixed(2)} lv. more.`);
    }
}

solve(10, 35);