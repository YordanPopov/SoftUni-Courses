function PrintNumbersAndSum(arr) {
    let result = '';
    let sum = 0;

    let num1 = parseInt(arr[0]);
    let num2 = parseInt(arr[1]);
    
    for (let i = num1; i <= num2; i++) {
        result += i + ' ';
        sum += i;
    }

    console.log(result.trimEnd());
    console.log(`Sum: ${sum}`)
}

PrintNumbersAndSum(['5', '10']);
PrintNumbersAndSum(['0', '26']);
PrintNumbersAndSum(['50', '60']);