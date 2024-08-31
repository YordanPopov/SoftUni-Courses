function solve(num1, num2, num3) {
    let sum = (n1, n2) => n1 + n2;
    let subtract = (n1, n2) => n1 - n2;

    let sumOfNumbers = sum(num1, num2);
    let result = subtract(sumOfNumbers, num3);

    console.log(result);
}

solve(23, 6, 10);
solve(1, 17, 30);
solve(42, 58, 100);