function solve([detergentBottles, ...input]) {
    let totalDetergent = detergentBottles * 750;
    let dishesCount = 0;
    let potsCount = 0;
    let isEnough = true;

    let index = 0;
    let currentInput = input[index];

    while (currentInput !== 'End') {

        if ((index + 1) % 3 === 0) {
            let pots = Number(currentInput);
            if (totalDetergent < (pots * 15)) {
                console.log(`Not enough detergent, ${(pots * 15) - totalDetergent} ml. more necessary!`);
                isEnough = false;
                break;
            } else {
                totalDetergent -= pots * 15;
                potsCount += pots;
            }

        } else {
            let dishes = Number(currentInput);
            if (totalDetergent < (dishes * 5)) {
                console.log(`Not enough detergent, ${(dishes * 5) - totalDetergent} ml. more necessary!`);
                isEnough = false;
                break;
            } else {
                totalDetergent -= dishes * 5;
                dishesCount += dishes;
            }
        }

        index++;
        currentInput = input[index];
    }

    if (isEnough) {
        console.log(`Detergent was enough!`);
        console.log(`${dishesCount} dishes and ${potsCount} pots were washed.`);
        console.log(`Leftover detergent ${totalDetergent} ml.`)
    }
}

// solve(["2 ",
//     "53",
//     "65",
//     "55",
//     "End"]);

solve(["1",
    "10",
    "15",
    "10",
    "12",
    "13",
    "30"]);

