function solve(number) {
    let firstDigit = number % 10;
    let secondDigit = Math.floor((number / 10) % 10);
    let thirdDigit = Math.floor(number / 100);

    for (let i = 1; i <= firstDigit; i++) {
        for (let j = 1; j <= secondDigit; j++) {
            for (let k = 1; k <= thirdDigit; k++) {
                const result = i * j * k;
                console.log(`${i} * ${j} * ${k} = ${result};`);
            }
        }
    }
}

solve(222);