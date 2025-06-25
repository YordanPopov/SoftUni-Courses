function solve([fisrtPlayerEggs, secondPlayerEggs, ...input]) {
    fisrtPlayerEggs = Number(fisrtPlayerEggs);
    secondPlayerEggs = Number(secondPlayerEggs);

    let index = 0;

    while (input[index] !== 'End') {
        const command = input[index++];

        if (command == 'one') {
            secondPlayerEggs--;
        } else if (command == 'two') {
            fisrtPlayerEggs--;
        }

        if (fisrtPlayerEggs === 0) {
            console.log(`Player one is out of eggs. Player two has ${secondPlayerEggs} eggs left.`);
            return;
        } else if (secondPlayerEggs === 0) {
            console.log(`Player two is out of eggs. Player one has ${fisrtPlayerEggs} eggs left.`);
            return;
        }
    }

    console.log(`Player one has ${fisrtPlayerEggs} eggs left.`);
    console.log(`Player two has ${secondPlayerEggs} eggs left.`)
}

solve(["5",
    "4",
    "one",
    "two",
    "one",
    "two",
    "two",
    "End"]);
