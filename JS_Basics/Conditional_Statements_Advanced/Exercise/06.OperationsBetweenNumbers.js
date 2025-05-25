function solve(number1, number2, op) {
    let result;
    let evenOrOdd = '';

    switch (op) {
        case '+':
            result = number1 + number2;
            evenOrOdd = isEvenOrOdd(result);
            console.log(`${number1} ${op} ${number2} = ${result} - ${evenOrOdd}`);
            break;
        case '-':
            result = number1 - number2;
            evenOrOdd = isEvenOrOdd(result);
            console.log(`${number1} ${op} ${number2} = ${result} - ${evenOrOdd}`);
            break;
        case '*':
            result = number1 * number2;
            evenOrOdd = isEvenOrOdd(result);
            console.log(`${number1} ${op} ${number2} = ${result} - ${evenOrOdd}`);
            break;
        case '/':
            if (number2 === 0) {
                console.log(`Cannot divide ${number1} by zero`);
            } else {
                result = number1 / number2;
                console.log(`${number1} / ${number2} = ${result.toFixed(2)}`);
            }
            break;
        case '%':
            if (number2 !== 0) {
                result = number1 % number2;
                console.log(`${number1} % ${number2} = ${result}`)
            } else {
                console.log(`Cannot divide ${number1} by zero`);
            }
            break;
        default:
            break;
    }

    function isEvenOrOdd(num) {
        if (num % 2 === 0) {
            return 'even';
        } else {
            return 'odd';
        }
    }
}

solve(10, 0, '/');