function solve(firstDigitMax, secondDigitMax, thirdDigitMax) {
    let pinCodes = [];

    for (let firstDigit = 1; firstDigit <= firstDigitMax; firstDigit++) {
        for (let secondDigit = 1; secondDigit <= secondDigitMax; secondDigit++) {
            for (let thirdDigit = 1; thirdDigit <= thirdDigitMax; thirdDigit++) {
                let isUnique = isEven(firstDigit) && isEven(thirdDigit) && isPrime(secondDigit);
                if (isUnique) {
                    pinCodes.push(`${firstDigit} ${secondDigit} ${thirdDigit}`);
                }
            }
        }
    }

    console.log(pinCodes.join('\n'));

    function isEven(number) {
        if (number % 2 === 0) {
            return true;
        } else {
            return false;
        }
    }

    function isPrime(number) {
        if (number <= 1) return false;
        if (number === 2) return true;
        if (number % 2 === 0) return false;

        const sqrt = Math.sqrt(number);
        for (let i = 3; i <= sqrt; i += 2) {
            if (number % i === 0) return false;
        }

        return true;
    }
}

solve(8, 2, 8);