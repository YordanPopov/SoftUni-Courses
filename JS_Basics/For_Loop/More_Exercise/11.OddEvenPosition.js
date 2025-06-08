function solve([n, ...numbers]) {
    n = Number(n);
    numbers = numbers.map(Number);

    let oddSum = 0;
    let evenSum = 0;
    let oddMin = Number.MAX_SAFE_INTEGER;
    let oddMax = Number.MIN_SAFE_INTEGER;
    let evenMin = Number.MAX_SAFE_INTEGER;
    let evenMax = Number.MIN_SAFE_INTEGER;

    for (let i = 1; i <= numbers.length; i++) {
        const num = numbers[i - 1];
        if (i % 2 === 0) {
            evenSum += num;
            if (num < evenMin) {
                evenMin = num;
            }
            if (num > evenMax) {
                evenMax = num;
            }
        } else {
            oddSum += num;
            if (num < oddMin) {
                oddMin = num;
            }
            if (num > oddMax) {
                oddMax = num;
            }
        }
    }

    console.log(`OddSum=${oddSum.toFixed(2)},`);
    console.log(`OddMin=${oddMin === (Number.MAX_SAFE_INTEGER) ? 'No' : oddMin.toFixed(2)},`);
    console.log(`OddMax=${oddMax === (Number.MIN_SAFE_INTEGER) ? 'No' : oddMax.toFixed(2)},`);
    console.log(`EvenSum=${evenSum.toFixed(2)},`);
    console.log(`EvenMin=${evenMin === Number.MAX_SAFE_INTEGER ? 'No' : evenMin.toFixed(2)},`);
    console.log(`EvenMax=${evenMax === Number.MIN_SAFE_INTEGER ? 'No' : evenMax.toFixed(2)}`);
}

solve(["6",
    "2",
    "3",
    "5",
    "4",
    "2",
    "1"]);