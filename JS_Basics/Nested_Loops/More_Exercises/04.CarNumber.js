function solve(startNum, endNum) {
    const specialNumbers = [];

    for (let num1 = startNum; num1 <= endNum; num1++) {
        for (let num2 = startNum; num2 <= endNum; num2++) {
            for (let num3 = startNum; num3 <= endNum; num3++) {
                for (let num4 = startNum; num4 <= endNum; num4++) {
                    let isSpecial = isSpecialNumber(num1, num2, num3, num4);
                    if (isSpecial) {
                        specialNumbers.push(`${num1}${num2}${num3}${num4}`);
                    }
                }
            }
        }
    }

    console.log(specialNumbers.join(' '));

    function isSpecialNumber(num1, num2, num3, num4) {
        let sum = num2 + num3;

        if (num1 % 2 === 0 && num4 % 2 !== 0 && num1 > num4 && sum % 2 === 0) {
            return true;
        } else if (num1 % 2 !== 0 && num4 % 2 === 0 && num1 > num4 && sum % 2 === 0) {
            return true;
        } else {
            return false;
        }
    }
}

solve(3, 5);