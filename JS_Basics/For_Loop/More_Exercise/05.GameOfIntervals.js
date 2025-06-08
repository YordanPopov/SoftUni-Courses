function solve([moves, ...numbers]) {
    moves = Number(moves);
    numbers = numbers.map(Number);

    let score = 0;
    let intervals = {
        "0-9": 0,
        "10-19": 0,
        "20-29": 0,
        "30-39": 0,
        "40-50": 0,
        "invalid": 0
    };

    for (let i = 0; i < moves; i++) {
        const number = numbers[i];

        if (number >= 0 && number <= 50) {
            if (number <= 9) {
                intervals["0-9"]++;
                score += number * 0.20;
            } else if (number <= 19) {
                intervals["10-19"]++;
                score += number * 0.30;
            } else if (number <= 29) {
                intervals["20-29"]++;
                score += number * 0.40;
            } else if (number <= 39) {
                intervals["30-39"]++;
                score += 50;
            } else if (number <= 50) {
                intervals["40-50"]++;
                score += 100;
            }
        } else {
            intervals["invalid"]++;
            score /= 2;
        }
    }

    console.log(`${score.toFixed(2)}`);
    console.log(`From 0 to 9: ${(intervals["0-9"] / moves * 100.00).toFixed(2)}%`);
    console.log(`From 10 to 19: ${(intervals["10-19"] / moves * 100.00).toFixed(2)}%`);
    console.log(`From 20 to 29: ${(intervals["20-29"] / moves * 100.00).toFixed(2)}%`);
    console.log(`From 30 to 39: ${(intervals["30-39"] / moves * 100.00).toFixed(2)}%`);
    console.log(`From 40 to 50: ${(intervals["40-50"] / moves * 100.00).toFixed(2)}%`);
    console.log(`Invalid numbers: ${(intervals["invalid"] / moves * 100.00).toFixed(2)}%`);
}

solve(["10",
    "43",
    "57",
    "-12",
    "23",
    "12",
    "0",
    "50",
    "40",
    "30",
    "20"]);