function solve([...input]) {
    let index = 0;
    let currentInput = input[index];

    let maxNumber = Number.MIN_SAFE_INTEGER;

    while (currentInput !== 'Stop') {
        let number = Number(currentInput);

        if (number > maxNumber) {
            maxNumber = number;
        }

        index++;
        currentInput = input[index];
    }

    console.log(maxNumber);
}

solve(["100",
    "99",
    "80",
    "70",
    "Stop"]);