function solve(start, end) {
    let numbers = [];

    for (let i = start; i <= end; i++) {
        let currentNum = "" + i;
        let evenSum = 0;
        let oddSum = 0;

        for (let j = 0; j < currentNum.length; j++) {
            let currentDigit = Number(currentNum.charAt(j));

            if (j % 2 === 0) {
                evenSum += currentDigit;
            } else {
                oddSum += currentDigit;
            }
        }
        if (oddSum === evenSum) {
            numbers.push(currentNum);
        }
    }

    console.log(numbers.join(' '));
}

solve(123456, 124000)