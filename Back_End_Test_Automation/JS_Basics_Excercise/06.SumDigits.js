// function printSumOfDigits(number) {
//     let sum = 0;

//     while (number > 0) {
//         let digit = number % 10;
//         sum += digit;
//         number = Math.floor(number / 10);
//     }

//     console.log(sum);
// }

function printSumOfDigits(input){
    let numberToText = input.toString();
    let sum = 0;

    for (const digit of numberToText) {
        sum += parseInt(digit);
    }

    console.log(sum); 
}

printSumOfDigits(245678);
printSumOfDigits(97561);
printSumOfDigits(543);