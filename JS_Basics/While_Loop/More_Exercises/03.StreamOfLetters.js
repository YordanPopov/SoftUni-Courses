function solve(input) {
    let result = "";
    let word = "";
    let cFound = false;
    let oFound = false;
    let nFound = false;

    let index = 0;
    let currentInput = input[index];

    while (currentInput !== 'End') {
        let char = currentInput;

        if (!/^[A-Za-z]$/.test(char)) {
            index++;
            currentInput = input[index];
            continue;
        }

        if (char === 'c' && !cFound) {
            cFound = true;
        } else if (char === 'o' && !oFound) {
            oFound = true;
        } else if (char === 'n' && !nFound) {
            nFound = true;
        } else {
            word += char;
        }

        if (cFound && oFound && nFound) {
            result += word + " ";
            word = "";
            cFound = oFound = nFound = false;
        }

        index++;
        currentInput = input[index];
    }

    console.log(result.trim());
}


solve(["%",
    "!",
    "c",
    "^",
    "B",
    "`",
    "o",
    "%",
    "o",
    "o",
    "M",
    ")",
    "{",
    "n",
    "\\",
    "A",
    "D",
    "End"]);
