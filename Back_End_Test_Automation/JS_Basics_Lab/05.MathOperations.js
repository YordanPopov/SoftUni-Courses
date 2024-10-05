function printResult(num1, num2, op) {
    let result = 0;

    switch (op) {
        case '+': result = num1 + num2; break;
        case '-': result = num1 - num2; break;
        case '*': result = num1 * num2; break;
        case '/': result = num1 / num2; break;
        case '%': result = num1 % num2; break;
        case '**': result = num1 ** num2; break;
        default:
            console.log('Invalid operator!');
            break;
    }

    console.log(result);
}

printResult(5, 6, '+');
printResult(3, 5.5, '*');