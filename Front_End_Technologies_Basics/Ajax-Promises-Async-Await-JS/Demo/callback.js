/* function myDisplayer(some) {
    document.getElementById("demo-callback").innerHTML = some;
}

function calculator(num1, num2, myCallback) {
    let sum = num1 + num2;
    myCallback(sum);
}

calculator(5, 5, myDisplayer); */

const numbers = [4, 1, -20, -7, 5, 9, -6];

const posNumbers = removeNeg(numbers, (x) => x >= 0);

document.getElementById("demo-callback").innerHTML = posNumbers;


function removeNeg(numbers, callback) {
    const arr = [];

    for (const x of numbers) {
        if (callback(x)) {
            arr.push(x);
        }
    }

    return arr;
}