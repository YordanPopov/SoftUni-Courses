function solve([n, ...numbers]) {
    n = Number(n);
    numbers = numbers.map(Number);

    let sum = 0;
    let maxDiff = 0;

    for (let i = 0; i < n * 2; i += 2) {
        let num1 = numbers[i];
        let num2 = numbers[i + 1];

        let currentSum = num1 + num2;

        if (i > 0) {
            let diff = Math.abs(currentSum - sum);
            if (diff > maxDiff) {
                maxDiff = diff;
            }
        }

        sum = currentSum;
    }

    if (maxDiff === 0) {
        console.log(`Yes, value=${sum}`);
    } else {
        console.log(`No, maxdiff=${maxDiff}`);
    }
}

solve(['2', '-1', '0', '0', '-1']);




