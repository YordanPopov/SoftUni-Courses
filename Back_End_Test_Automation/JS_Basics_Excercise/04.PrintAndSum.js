function PrintNumbersAndSum(num1, num2) {
    let result = '';
    let sum = 0;
    
    for (let i = num1; i <= num2; i++) {
        result += i + ' ';
        sum += i;
    }

    console.log(result.trimEnd());
    console.log(`Sum: ${sum}`)
}

PrintNumbersAndSum(5, 10);
PrintNumbersAndSum(0, 26);
PrintNumbersAndSum(50, 60);