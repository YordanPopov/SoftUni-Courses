function solve(input) {
    let primeNumberSum = 0;
    let nonPrimeNumberSum = 0;

    let index = 0;
    let currentInput = input[index];

    while (currentInput !== 'stop') {
        let currentNumber = Number(currentInput);

        if (currentNumber < 0) {
            console.log('Number is negative.');
        } else if (isPrime(currentNumber)) {
            primeNumberSum += currentNumber;
        } else {
            nonPrimeNumberSum += currentNumber;
        }

        index++;
        currentInput = input[index];
    }

    console.log(`Sum of all prime numbers is: ${primeNumberSum}`);
    console.log(`Sum of all non prime numbers is: ${nonPrimeNumberSum}`);

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

solve(["0",
    "-9",
    "0",
    "stop"])

