// NaN - Not a Number
let x = 100 / "Apple"; // NaN
let y = 100 / "10"; // 10

let a = NaN;
let b = 5;
let z = a / b; // NaN
let n = "5" + a; // 5NaN

console.log(isNaN(x));
console.log(x);
console.log(y);
console.log(z);
console.log(n);
console.log(typeof NaN); // number

// Infinity
let myNumber = 2;

while (myNumber != Infinity) {
    myNumber *= myNumber;
    console.log(myNumber);  
}

console.log(2 / 0); // Infinity
console.log(-2 / 0); // -Infinity
console.log(typeof Infinity); // number

// BigInt
let bigNumber = 999999999999999n;
let bigNumber2 = BigInt(1234567890123456789012345);

// toString()
let num = 100.5325;
let numToStr = num.toString();


// toFixed()
console.log(num.toFixed(2));

// toPrecision()
console.log(num.toPrecision(3));

// Converting Variables to Number
let str = "100";
console.log(Number(str));
console.log(parseInt(str));














