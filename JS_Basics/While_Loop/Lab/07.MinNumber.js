function solve([...input]) {
    let index = 0;
    let currentInput = input[index];

    let minNumber = Number.MAX_SAFE_INTEGER;

    while (currentInput !== 'Stop') {
        let number = Number(currentInput);

        if (number < minNumber) {
            minNumber = number;
        }

        index++;
        currentInput = input[index];
    }

    console.log(minNumber);
}

solve(["100",
    "99",
    "80",
    "70",
    "Stop"]);