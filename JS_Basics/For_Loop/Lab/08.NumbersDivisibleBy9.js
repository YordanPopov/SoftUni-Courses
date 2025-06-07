function solve(num1, num2) {
    let numbersDivisibleBy9 = [];
    let sum = 0

    for (let i = num1; i <= num2; i++) {
        if (i % 9 === 0) {
            numbersDivisibleBy9.push(i);
            sum += i;
        }
    }

    console.log(`The sum: ${sum}`);
    console.log(`${numbersDivisibleBy9.join('\n')}`);
}

solve(100, 200);