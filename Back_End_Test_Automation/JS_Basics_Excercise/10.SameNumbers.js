function printSum(number) {
    let sum = 0;
    let isSame = true;
    let lastDigit = number % 10;
    let copyNumber = number;

    while (copyNumber > 0) {
        let digit = copyNumber % 10;
        if (digit != lastDigit) {
            isSame = false;
            break;
        }

        copyNumber = Math.floor(copyNumber / 10);
    }

    while (number > 0) {
        let digit = number % 10;
        sum += digit;
        number = Math.floor(number / 10);
    }

    console.log(isSame);
    console.log(sum);
}

printSum(2222222);
printSum(1234);