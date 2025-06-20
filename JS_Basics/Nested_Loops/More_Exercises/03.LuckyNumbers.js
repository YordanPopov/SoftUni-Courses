function solve(n) {
    const luckyNumbers = [];

    for (let firstDigit = 1; firstDigit <= 9; firstDigit++) {
        for (let secondDigit = 1; secondDigit <= 9; secondDigit++) {
            for (let thirdDigit = 1; thirdDigit <= 9; thirdDigit++) {
                for (let fourthDigit = 1; fourthDigit <= 9; fourthDigit++) {
                    let isLucky = isLuckyNumber(firstDigit, secondDigit, thirdDigit, fourthDigit, n);
                    if (isLucky) {
                        luckyNumbers.push(`${firstDigit}${secondDigit}${thirdDigit}${fourthDigit}`);
                    }
                }
            }
        }
    }

    console.log(luckyNumbers.join(' '));

    function isLuckyNumber(num1, num2, num3, num4, n) {
        let sum1 = num1 + num2;
        let sum2 = num3 + num4;

        if (sum1 === sum2 && n % sum1 === 0) {
            return true;
        }

        return false;
    }
}

solve(7);